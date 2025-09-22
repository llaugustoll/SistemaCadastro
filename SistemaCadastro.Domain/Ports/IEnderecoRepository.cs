using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Domain.Ports;
public interface IEnderecoRepository
{
    Task<Endereco> GetByIdAsync(Guid id);
    Task<Endereco> AddAsync(Endereco endereco);
}
