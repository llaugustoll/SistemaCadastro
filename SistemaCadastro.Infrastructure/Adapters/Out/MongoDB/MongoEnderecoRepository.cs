using MongoDB.Driver;
using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Infrastructure.Models.Mongo;

namespace SistemaCadastro.Infrastructure.Adapters.Out.MongoDB;

public class MongoEnderecoRepository : IEnderecoRepository
{
    private readonly IMongoCollection<EnderecoDocument> _collection;

    public MongoEnderecoRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<EnderecoDocument>("Enderecos");
    }
    public Task<Endereco> GetByIdAsync(Guid id)
    {
        return Task.FromResult(new Endereco { Cep = "0125151" });
    }
    public async Task<Endereco> AddAsync(Endereco endereco)
    {
        var doc = EnderecoMapper.ToDocument(endereco);
        await _collection.InsertOneAsync(doc);

        return EnderecoMapper.ToDomain(doc);
    }
}
