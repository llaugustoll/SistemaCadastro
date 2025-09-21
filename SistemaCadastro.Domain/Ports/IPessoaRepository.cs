using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Domain.Ports;

public interface IPessoaRepository
{
    Task<Pessoa> GetByIdAsync(Guid id);
    Task AddAsync(Pessoa cadastro);
}
