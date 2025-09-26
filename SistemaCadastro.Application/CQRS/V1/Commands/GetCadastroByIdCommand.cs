using MediatR;
using SistemaCadastro.Application.Models.Responses;

namespace SistemaCadastro.Application.CQRS.V1.Commands;

public record GetCadastroByIdCommand(int id) : IRequest<GetCadastroByIdResponse>
{
}
