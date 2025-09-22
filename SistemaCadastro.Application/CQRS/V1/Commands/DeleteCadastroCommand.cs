using MediatR;

namespace SistemaCadastro.Application.CQRS.V1.Commands
{
    public record class DeleteCadastroCommand(string Documento) : IRequest<bool>
    {
    }
}
