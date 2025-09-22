using MediatR;
using Moq;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Application.CQRS.V1.Handlers;
using SistemaCadastro.Domain.DataStructure;
using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;
using Xunit;

public class CreateCadastroHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreatePessoaFisica_WhenCommandIsValid()
    {
        var pessoaRepositoryMock = new Mock<IPessoaRepository>();
        var enderecoApiMock = new Mock<IEnderecoApi>();
        var mediatorMock = new Mock<IMediator>();

        var command = new CreateCadastroCommand(
            Documento: "12345678901",
            Nome: "João da Silva",
            Cep: "01001000",
            NumeroResidencia: "123"
        );

        var enderecoApiResponse = new
        {
            Logradouro = "Praça da Sé",
            Bairro = "Sé",
            Localidade = "São Paulo",
            Uf = "SP",
            Cep = "01001000"
        };

        enderecoApiMock
            .Setup(x => x.ObterEnderecoViaCepAsync(It.IsAny<string>()))
            .ReturnsAsync(new EnderecoResponse
            {
                Logradouro = enderecoApiResponse.Logradouro,
                Bairro = enderecoApiResponse.Bairro,
                Localidade = enderecoApiResponse.Localidade,
                Uf = enderecoApiResponse.Uf,
                Cep = enderecoApiResponse.Cep
            });

        mediatorMock
            .Setup(x => x.Send(It.IsAny<CreateEnderecoCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Endereco { Id = "SAssadas"});

        pessoaRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<PessoaFisica>()))
            .ReturnsAsync((PessoaFisica p) =>
            {
                p.Id = 42; // Simulando Id gerado pelo banco
                return p;
            });

        var handler = new CreateCadastroHandler(
            pessoaRepositoryMock.Object,
            enderecoApiMock.Object,
            mediatorMock.Object
        );

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(42, result.Id);

        pessoaRepositoryMock.Verify(x => x.AddAsync(It.IsAny<PessoaFisica>()), Times.Once);
        enderecoApiMock.Verify(x => x.ObterEnderecoViaCepAsync(command.Cep), Times.Once);
        mediatorMock.Verify(x => x.Send(It.IsAny<CreateEnderecoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}