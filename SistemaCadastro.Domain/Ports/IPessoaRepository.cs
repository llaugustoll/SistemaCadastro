using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Domain.Ports;

public interface IPessoaRepository
{
    Task<Pessoa> GetByIdAsync(int id);
    Task<Pessoa> AddAsync(Pessoa cadastro);
    Task<bool> DeleteAsync(string documento);
}
