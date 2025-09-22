namespace SistemaCadastro.API.Controllers.V1.Models;

public class CreateCadastroRequest
{
    public string Documento { get; set; }
    public string Nome { get; set; }
    public string Cep { get; set; }
    public string? NumeroResidencia { get; set; }
}
