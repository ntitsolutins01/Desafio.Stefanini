namespace Desafio.Stefanini.Application.Produtos.Queries.GetProdutosWithPagination;

public class GetProdutosWithPaginationQueryValidator : AbstractValidator<GetProdutosWithPaginationQuery>
{
    public GetProdutosWithPaginationQueryValidator()
    {

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber pelo menos maior ou igual a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize pelo menos maior ou igual a 1.");
    }
}
