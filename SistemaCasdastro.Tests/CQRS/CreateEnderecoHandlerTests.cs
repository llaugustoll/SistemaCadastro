
using Moq;
using Xunit;
using MediatR;
using SistemaCadastro.Application.CQRS.V1.Handlers;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Entities;
using SistemaCadastro.Domain.Ports;

public class CreateEnderecoHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateEndereco_WhenCommandIsValid()
    {
        var enderecoRepositoryMock = new Mock<IEnderecoRepository>();

        var command = new CreateEnderecoCommand(
            Logradouro: "Rua das Flores",
            Numero: "123",
            Bairro: "Centro",
            Estado: "SP",
            Cep: "01001000",
            Cidade: "São Paulo"
        );

        enderecoRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Endereco>()))
            .ReturnsAsync((Endereco e) =>
            {
                e.Id = "Teste1";
                return e;
            });

        var handler = new CreateEnderecoHandler(enderecoRepositoryMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("Teste1", result.Id);
        Assert.Equal(command.Logradouro, result.Logradouro);
        Assert.Equal(command.Numero, result.Numero);
        Assert.Equal(command.Bairro, result.Bairro);
        Assert.Equal(command.Cidade, result.Cidade);
        Assert.Equal(command.Estado, result.Estado);
        Assert.Equal(command.Cep, result.Cep);

        enderecoRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Endereco>()), Times.Once);
    }
}