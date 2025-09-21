using Refit;
using SistemaCadastro.Infrastructure.Models;

namespace SistemaCadastro.Infrastructure.Adapters.Out.Api;

public interface IViaCepApi
{
    [Get("/ws/{cep}/json/")]
    Task<ViaCepRespose> ObterEnderecoViaCepAsync(string cep);
}
