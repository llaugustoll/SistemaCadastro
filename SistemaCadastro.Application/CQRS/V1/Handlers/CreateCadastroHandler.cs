using MediatR;
using SistemaCadastro.Application.Models.Responses;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Application.CQRS.V1.Handlers;

public class CreateCadastroHandler(IPessoaRepository pessoaRepository) : IRequestHandler<CreateCadastroCommand, CreateCadastroResponse>
{
    public async Task<CreateCadastroResponse> Handle(CreateCadastroCommand request, CancellationToken cancellationToken)
    {
        var endereco = new Endereco
        {
            Cep = request.cep,
            Logradouro = "Rua teste",
            Numero = "1234",
            Bairro = "jd São paulo",
            Cidade = "São Paulo",
            Estado = "São Paulo"
        };
        var pessoa = new PessoaFisica
        {
            Cpf = request.cpf,
            Nome = request.nome,
            Endereco = endereco,
            DataNascimento = DateTime.UtcNow
            
        };

        var pessoaCriada = await pessoaRepository.AddAsync(pessoa);

        return new CreateCadastroResponse
        {
            Id = pessoaCriada.Id,
        };
    }
}
