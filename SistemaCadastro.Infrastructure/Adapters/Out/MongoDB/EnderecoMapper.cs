using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Infrastructure.Models.Mongo;

namespace SistemaCadastro.Infrastructure.Adapters.Out.MongoDB;

internal class EnderecoMapper
{
    public static Endereco ToDomain(EnderecoDocument doc) => new()
    {
        Id = doc.Id,
        Logradouro = doc.Logradouro,
        Numero = doc.Numero,
        Complemento = doc.Complemento,
        Bairro = doc.Bairro,
        Cidade = doc.Cidade
    };

    public static EnderecoDocument ToDocument(Endereco domain) => new()
    {
        Id = domain.Id,
        Logradouro = domain.Logradouro,
        Numero = domain.Numero,
        Complemento = domain.Complemento,
        Bairro = domain.Bairro,
        Cidade = domain.Cidade
    };
}
