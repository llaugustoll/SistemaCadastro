using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Infrastructure.Configs;

namespace SistemaCadastro.Infrastructure.Adapters.Out.Databases;
public class PostgresPessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PostgresPessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pessoa> GetByIdAsync(Guid id)
    {
        return await _context.Pessoas.FindAsync(id);
    }

    public async Task<Pessoa> AddAsync(Pessoa pessoa)
    {
        var pessoaCriada = _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return pessoaCriada.Entity;
    }
}
    //    private readonly AppDbContext _context;

    //    public PostgresPessoaRepository(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Pessoa> GetByIdAsync(Guid id) =>
    //        await _context.Pessoas.FindAsync(id);

    //    public async Task AddAsync(Pessoa pessoa)
    //    {
    //        _context.Pessoas.Add(pessoa);
    //        await _context.SaveChangesAsync();
    //    }
    //}
