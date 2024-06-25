namespace Desafio.Stefanini.Application.Pedidos.Queries.GetPedidosWithPagination;

public class GetPedidosWithPaginationQueryValidator : AbstractValidator<GetPedidosWithPaginationQuery>
{
    public GetPedidosWithPaginationQueryValidator()
    {

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber pelo menos maior ou igual a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize pelo menos maior ou igual a 1.");
    }
}
