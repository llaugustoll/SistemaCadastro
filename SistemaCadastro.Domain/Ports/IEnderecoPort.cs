using SistemaCadastro.Domain.DataStructure;

namespace SistemaCadastro.Domain.Ports;

public interface IEnderecoPort
{
    Task<EnderecoViaCepResponse> ObterEnderecoViaCepAsync();
}
