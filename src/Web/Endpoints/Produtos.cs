using Desafio.Stefanini.Application.Common.Models;
using Desafio.Stefanini.Application.Produtos.Commands.CreateProduto;
using Desafio.Stefanini.Application.Produtos.Commands.DeleteProduto;
using Desafio.Stefanini.Application.Produtos.Commands.UpdateProduto;
using Desafio.Stefanini.Application.Produtos.Queries.GetProdutosWithPagination;

namespace Desafio.Stefanini.Web.Endpoints;

public class Produtos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetProdutosWithPagination)
            .MapPost(CreateProduto)
            .MapPut(UpdateProduto, "{id}")
            .MapDelete(DeleteProduto, "{id}");
    }

    public Task<PaginatedList<ProdutoDto>> GetProdutosWithPagination(ISender sender, [AsParameters] GetProdutosWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateProduto(ISender sender, CreateProdutoCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateProduto(ISender sender, int id, UpdateProdutoCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }


    public async Task<IResult> DeleteProduto(ISender sender, int id)
    {
        await sender.Send(new DeleteProdutoCommand(id));
        return Results.NoContent();
    }
}
