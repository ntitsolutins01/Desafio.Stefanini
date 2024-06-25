using Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;
using Desafio.Stefanini.Application.Pedidos.Commands.UpdatePedido;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.FunctionalTests.Pedidos.Commands;

using static Testing;

public class UpdatePedidoTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidPedidoId()
    {
        var command = new UpdatePedidoCommand { Id = 99, NomeCliente = "Souza" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdatePedido()
    {
        var userId = await RunAsDefaultUserAsync();


        var pedidoId = await SendAsync(new CreatePedidoCommand
        {
            NomeCliente = "Fabio",
            EmailCliente = "ntitsolutions01@gmail.com",
            Pago = true
        });

        var command = new UpdatePedidoCommand
        {
            Id = pedidoId,
            NomeCliente = "Muniz"
        };

        await SendAsync(command);

        var item = await FindAsync<Pedido>(pedidoId);

        item.Should().NotBeNull();
        item!.NomeCliente.Should().Be(command.NomeCliente);
        item.LastModifiedBy.Should().NotBeNull();
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
