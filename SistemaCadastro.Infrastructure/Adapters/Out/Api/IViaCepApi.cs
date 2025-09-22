using Refit;
using SistemaCadastro.Domain.DataStructure;
using SistemaCadastro.Infrastructure.Models;

namespace SistemaCadastro.Infrastructure.Adapters.Out.Api;

public interface IViaCepApi
{
    [Get("/ws/{cep}/json/")]
    Task<EnderecoResponse> GetEnderecoByCepAsync(string cep);
}
