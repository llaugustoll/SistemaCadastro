using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace SistemaCadastro.Infrastructure.Adapters.Out.Databases;
public class PostgresPessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PostgresPessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pessoa> GetByIdAsync(int id)
    {
        return await _context.Pessoas.FindAsync(id);
    }

    public async Task<Pessoa> AddAsync(Pessoa pessoa)
    {
        var pessoaCriada = _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return pessoaCriada.Entity;
    }

    public async Task<bool> DeleteAsync(string documento)
    {
        Pessoa? pessoa = await _context.Pessoas.OfType<PessoaFisica>()
            .FirstOrDefaultAsync(pf => pf.Cpf == documento);

        if (pessoa == null)
        {
            pessoa = await _context.Pessoas.OfType<PessoaJuridica>()
                .FirstOrDefaultAsync(pj => pj.Cnpj == documento);
        }

        if (pessoa != null)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }

}

