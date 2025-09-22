using MediatR;
using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Application.CQRS.V1.Commands;

public record CreateEnderecoCommand(
    string Logradouro, 
    string Numero, 
    string Bairro, 
    string Estado, 
    string Cep,
    string Cidade
    ) : IRequest<Endereco>
{
}
