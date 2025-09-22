using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MediatR;
using SistemaCadastro.Application.CQRS.V1.Handlers;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Domain.Ports;

public class DeleteCadastroHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        var pessoaRepositoryMock = new Mock<IPessoaRepository>();
        var documento = "12345678901";

        pessoaRepositoryMock
            .Setup(x => x.DeleteAsync(documento))
            .ReturnsAsync(true);

        var handler = new DeleteCadastroHandler(pessoaRepositoryMock.Object);
        var command = new DeleteCadastroCommand(documento);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        pessoaRepositoryMock.Verify(x => x.DeleteAsync(documento), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnFalse_WhenDeleteFails()
    {

        var pessoaRepositoryMock = new Mock<IPessoaRepository>();
        var documento = "98765432100";

        pessoaRepositoryMock
            .Setup(x => x.DeleteAsync(documento))
            .ReturnsAsync(false);

        var handler = new DeleteCadastroHandler(pessoaRepositoryMock.Object);
        var command = new DeleteCadastroCommand(documento);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result);
        pessoaRepositoryMock.Verify(x => x.DeleteAsync(documento), Times.Once);
    }
}