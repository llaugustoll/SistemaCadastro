using SistemaCadastro.Domain.DataStructure;

namespace SistemaCadastro.Domain.Ports;

public interface IEnderecoApi
{
    Task<EnderecoResponse> ObterEnderecoViaCepAsync();
}
