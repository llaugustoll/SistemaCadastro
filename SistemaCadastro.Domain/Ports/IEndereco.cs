using SistemaCadastro.Domain.DataStructure;

namespace SistemaCadastro.Domain.Ports;

public interface IEndereco
{
    Task<EnderecoResponse> ObterEnderecoViaCepAsync();
}
