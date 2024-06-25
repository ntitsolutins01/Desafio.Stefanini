using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.Produtos.Queries.GetProdutosWithPagination;

public class ProdutoDto
{
    public int Id { get; init; }
    public string? NomeProduto { get; init; }
    public decimal? Valor { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Produto, ProdutoDto>();
        }
    }
}
