namespace SistemaCadastro.Domain.Entities;
public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string Telefone { get; set; }
    public string Tipo { get; set; }
    public virtual Endereco Endereco { get; set; }

    
}
