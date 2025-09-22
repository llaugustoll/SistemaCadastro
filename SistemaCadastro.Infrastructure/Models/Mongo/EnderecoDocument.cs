using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaCadastro.Infrastructure.Models.Mongo;

internal class EnderecoDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
}