namespace SistemaCadastro.Domain.Entity;

public class PessoaFisica : Pessoa
{
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}
