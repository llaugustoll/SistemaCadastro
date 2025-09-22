using MediatR;
using SistemaCadastro.Application.Models.Responses;

namespace SistemaCadastro.Application.CQRS.V1.Commands;

public record class CreateCadastroCommand(string cpf, string nome, string cep) : IRequest<CreateCadastroResponse> { }
