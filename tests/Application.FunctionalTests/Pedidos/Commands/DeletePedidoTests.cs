using Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;
using Desafio.Stefanini.Application.Pedidos.Commands.DeletePedido;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.FunctionalTests.Pedidos.Commands;

using static Testing;

public class DeletePedidoTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidPedidoId()
    {
        var command = new DeletePedidoCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeletePedido()
    {

        var pedido = await SendAsync(new CreatePedidoCommand
        {
            NomeCliente = "Fabio",
            EmailCliente = "ntitsolutions01@gmail.com",
            Pago = true
        });

        await SendAsync(new DeletePedidoCommand(pedido));

        var item = await FindAsync<Pedido>(pedido);

        item.Should().BeNull();
    }
}
