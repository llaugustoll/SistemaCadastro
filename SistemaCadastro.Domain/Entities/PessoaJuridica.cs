namespace SistemaCadastro.Domain.Entities;

public class PessoaJuridica : Pessoa
{
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
}
