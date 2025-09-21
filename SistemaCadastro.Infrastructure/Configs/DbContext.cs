using SistemaCadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace SistemaCadastro.Infrastructure.Configs
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options) { }

        // DbSets -> mapeiam as entidades do domínio para tabelas no banco
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar configurações específicas
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }
    }
}
