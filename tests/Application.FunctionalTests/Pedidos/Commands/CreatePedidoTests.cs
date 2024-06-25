using Desafio.Stefanini.Application.Common.Exceptions;
using Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.FunctionalTests.Pedidos.Commands;

using static Testing;

public class CreatePedidoTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreatePedidoCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreatePedido()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreatePedidoCommand
        {
            NomeCliente = "Fabio",
            EmailCliente = "ntitsolutions01@gmail.com",
            Pago = true
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Pedido>(itemId);

        item.Should().NotBeNull();
        item!.EmailCliente.Should().Be(command.EmailCliente);
        item.NomeCliente.Should().Be(command.NomeCliente);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
