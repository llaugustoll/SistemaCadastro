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

    public async Task<Endereco> GetByIdAsync(string id)
    {
        var cursor = await _collection.FindAsync(e => e.Id == id);
        var doc = await cursor.FirstOrDefaultAsync();

        return EnderecoMapper.ToDomain(doc);
    }

    public async Task<Endereco> AddAsync(Endereco endereco)
    {
        var doc = EnderecoMapper.ToDocument(endereco);
        await _collection.InsertOneAsync(doc);

        return EnderecoMapper.ToDomain(doc);
    }
}
