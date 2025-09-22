using MediatR;
using SistemaCadastro.Application.Models.Responses;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Utils; 
using SistemaCadastro.Domain.Enums;

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
            Logradouro : enderecoApiResponse.Logradouro, 
            Numero : request.NumeroResidencia ?? "Sem Numero",
            Bairro : enderecoApiResponse.Bairro,
            Estado : enderecoApiResponse.Uf,
            Cep: enderecoApiResponse.Cep,
            Cidade : enderecoApiResponse.Localidade
        ));

        var tipoDocumento = Validadores.IdentificarDocumento(request.Documento);

        var pessoa = CriarPessoa(request, endereco, tipoDocumento);

        var pessoaCriada = await pessoaRepository.AddAsync(pessoa);

        return new CreateCadastroResponse
        {
            Id = pessoaCriada.Id
        };
    }

    private Pessoa CriarPessoa(CreateCadastroCommand request, Endereco endereco, TipoDocumentoEnum tipoDocumento)
    {
        return tipoDocumento switch
        {
            TipoDocumentoEnum.Cpf => new PessoaFisica
            {
                Cpf = request.Documento,
                Nome = request.Nome,
                EnderecoId = endereco.Id,
                DataNascimento = DateTime.UtcNow
            },
            TipoDocumentoEnum.Cnpj => new PessoaJuridica
            {
                Cnpj = request.Documento,
                Nome = request.Nome,
                EnderecoId = endereco.Id,
                RazaoSocial = request.Nome
            },
            _ => throw new NotSupportedException($"Tipo de documento {tipoDocumento} não suportado")
        };
    }
}
