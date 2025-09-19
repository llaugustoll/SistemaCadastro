using SistemaCadastro.Domain.DataStructure;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Infrastructure.Adapters;

public class EnderecoViaCep : IEnderecoPort
{
    public async Task<EnderecoViaCepResponse> ObterEnderecoViaCepAsync()
    {
        return await Task.FromResult(new EnderecoViaCepResponse());
    }
}
