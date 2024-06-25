using Desafio.Stefanini.Application.Common.Models;
using Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;
using Desafio.Stefanini.Application.Pedidos.Commands.DeletePedido;
using Desafio.Stefanini.Application.Pedidos.Commands.UpdatePedido;
using Desafio.Stefanini.Application.Pedidos.Queries.GetPedidosWithPagination;

namespace Desafio.Stefanini.Web.Endpoints;

public class Pedidos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPedidosWithPagination)
            .MapPost(CreatePedido)
            .MapPut(UpdatePedido, "{id}")
            .MapDelete(DeletePedido, "{id}");
    }

    public Task<PaginatedList<PedidoDto>> GetPedidosWithPagination(ISender sender, [AsParameters] GetPedidosWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreatePedido(ISender sender, CreatePedidoCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdatePedido(ISender sender, int id, UpdatePedidoCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }


    public async Task<IResult> DeletePedido(ISender sender, int id)
    {
        await sender.Send(new DeletePedidoCommand(id));
        return Results.NoContent();
    }
}
