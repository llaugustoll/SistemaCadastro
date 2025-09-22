using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Infrastructure.EntityConfigurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Email).HasMaxLength(100);
        builder.Property(p => p.Telefone).HasMaxLength(20);
  
        builder.HasDiscriminator<string>("Tipo")
               .HasValue<PessoaFisica>("PF")
               .HasValue<PessoaJuridica>("PJ");
        
        builder.HasOne(p => p.Endereco)
               .WithMany(e => e.Pessoa)
               .HasForeignKey(p => p.EnderecoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}