using MediatR;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Application.CQRS.V1.Handlers;

public class CreateEnderecoHandler(
    IEnderecoRepository enderecoRepository
    ) : IRequestHandler<CreateEnderecoCommand, Endereco>
{
    public async Task<Endereco> Handle(CreateEnderecoCommand request, CancellationToken cancellationToken)
    {

        var endereco = await enderecoRepository.AddAsync(new Endereco
        {
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Numero = request?.Numero,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Estado = request.Estado
        });

        return endereco;
    }
}
