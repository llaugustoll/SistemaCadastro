using MediatR;
using SistemaCadastro.Application.Models.Responses;

namespace SistemaCadastro.Application.CQRS.V1.Commands;

public record class CreateCadastroCommand(string Cpf, string Nome, string Cep, string NumeroResidencia) : IRequest<CreateCadastroResponse> { }
