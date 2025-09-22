//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using SistemaCadastro.Domain.Entities;

//namespace SistemaCadastro.Infrastructure.EntityConfigurations;

//public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
//{
//    public void Configure(EntityTypeBuilder<Endereco> builder)
//    {
//        builder.HasKey(e => e.Id);

//        builder.Property(e => e.Logradouro).IsRequired().HasMaxLength(150);
//        builder.Property(e => e.Numero).IsRequired().HasMaxLength(20);
//        builder.Property(e => e.Complemento).HasMaxLength(100);
//        builder.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
//        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
//        builder.Property(e => e.Estado).IsRequired().HasMaxLength(50);
//        builder.Property(e => e.Cep).IsRequired().HasMaxLength(10);

//        builder.HasMany(e => e.Pessoa)
//               .WithOne(p => p.Endereco)
//               .HasForeignKey(p => p.EnderecoId)
//               .OnDelete(DeleteBehavior.Cascade);
//    }
//}
