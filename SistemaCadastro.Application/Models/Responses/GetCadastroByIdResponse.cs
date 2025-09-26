﻿using SistemaCadastro.Domain.Entities;

namespace SistemaCadastro.Application.Models.Responses;

public class GetCadastroByIdResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string Documento {get; set; }
    public string TipoPessoa { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}
