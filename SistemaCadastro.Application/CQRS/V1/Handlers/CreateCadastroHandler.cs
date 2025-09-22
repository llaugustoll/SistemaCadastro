using MediatR;
using SistemaCadastro.Application.Models.Responses;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Application.CQRS.V1.Handlers;

public class CreateCadastroHandler(
    IPessoaRepository pessoaRepository, 
    IEnderecoApi enderecoApi, 
    IMediator mediator
    ) : IRequestHandler<CreateCadastroCommand, CreateCadastroResponse>
{
    public async Task<CreateCadastroResponse> Handle(CreateCadastroCommand request, CancellationToken cancellationToken)
    {

        var enderecoApiResponse = await enderecoApi.ObterEnderecoViaCepAsync(request.Cep);

        var endereco = await mediator.Send(new CreateEnderecoCommand(
            enderecoApiResponse.Logradouro, 
            request.NumeroResidencia ?? "Sem Numero",
            enderecoApiResponse.Bairro,
            enderecoApiResponse.Uf,
            enderecoApiResponse.Cep,
            enderecoApiResponse.Localidade
            ));


        var pessoa = new PessoaFisica
        {
            Cpf = request.Cpf,
            Nome = request.Nome,
            EnderecoId = endereco.Id,
            DataNascimento = DateTime.UtcNow
            
        };

        var pessoaCriada = await pessoaRepository.AddAsync(pessoa);

        return new CreateCadastroResponse
        {
            Id = pessoaCriada.Id,
        };
    }
}
