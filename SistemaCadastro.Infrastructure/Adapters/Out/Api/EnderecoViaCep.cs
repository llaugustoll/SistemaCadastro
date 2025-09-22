using SistemaCadastro.Domain.DataStructure;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Infrastructure.Adapters.Out.Api;

public class EnderecoViaCep : IEnderecoApi
{
    public readonly IViaCepApi _viaCepApi;
    public EnderecoViaCep(IViaCepApi viaCepApi)
    {
        _viaCepApi = viaCepApi;
    }
    public async Task<EnderecoResponse> ObterEnderecoViaCepAsync(string cep)
    {
        var endereco = await _viaCepApi.GetEnderecoByCepAsync(cep);

        return endereco;
    }
}
