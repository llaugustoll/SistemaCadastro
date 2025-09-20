using SistemaCadastro.Domain.DataStructure;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Infrastructure.Adapters.Out;

public class EnderecoViaCep : IEndereco
{
    public readonly IViaCepApi _viaCepApi;
    public EnderecoViaCep(IViaCepApi viaCepApi)
    {
        _viaCepApi = viaCepApi;
    }
    public async Task<EnderecoResponse> ObterEnderecoViaCepAsync()
    {
        return await Task.FromResult(new EnderecoResponse());
    }
}
