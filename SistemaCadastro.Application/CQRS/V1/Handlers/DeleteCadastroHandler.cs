
using MediatR;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Application.CQRS.V1.Handlers;

public class DeleteCadastroHandler(IPessoaRepository pessoaRepository) : IRequestHandler<DeleteCadastroCommand, bool>
{
    public async Task<bool> Handle(DeleteCadastroCommand request, CancellationToken cancellationToken)
    {
        var result = await pessoaRepository.DeleteAsync(request.Documento);
        
        return result;
    }
}
