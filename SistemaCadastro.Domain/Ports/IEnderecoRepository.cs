using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Domain.Ports;
public interface IEnderecoRepository
{
    Task<Endereco> GetByIdAsync(string id);
    Task<Endereco> AddAsync(Endereco endereco);
}
