using MediatR;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Application.Models.Responses;
using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Application.CQRS.V1.Handlers;

public class GetCadastroByIdHandler : IRequestHandler<GetCadastroByIdCommand, GetCadastroByIdResponse>
{
    IPessoaRepository _pessoaRepository;
    IEnderecoRepository _enderecoRepository;
    public GetCadastroByIdHandler(IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository)
    {
        _pessoaRepository = pessoaRepository;
        _enderecoRepository = enderecoRepository;
    }

    public async Task<GetCadastroByIdResponse> Handle(GetCadastroByIdCommand request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.GetByIdAsync(request.id);
        if (pessoa is null)
            return null;

        var endereco = await _enderecoRepository.GetByIdAsync(pessoa.EnderecoId);

        return new GetCadastroByIdResponse
        {
            Nome = pessoa.Nome,
            Documento = pessoa is PessoaFisica pf ? pf.Cpf : (pessoa as PessoaJuridica).Cnpj,
            TipoPessoa = pessoa is PessoaFisica ? "Física" : "Jurídica",
            Cep = endereco.Cep,
            Logradouro = endereco.Logradouro,
            Numero = endereco.Numero,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Cidade = endereco.Cidade,
            Estado = endereco.Estado
            
        };

    }
}
