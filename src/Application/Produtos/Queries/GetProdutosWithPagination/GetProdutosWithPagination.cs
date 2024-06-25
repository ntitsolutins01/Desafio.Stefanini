using Desafio.Stefanini.Application.Common.Interfaces;
using Desafio.Stefanini.Application.Common.Mappings;
using Desafio.Stefanini.Application.Common.Models;

namespace Desafio.Stefanini.Application.Produtos.Queries.GetProdutosWithPagination;

public record GetProdutosWithPaginationQuery : IRequest<PaginatedList<ProdutoDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProdutosWithPaginationQueryHandler : IRequestHandler<GetProdutosWithPaginationQuery, PaginatedList<ProdutoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProdutosWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProdutoDto>> Handle(GetProdutosWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Produtos
            .OrderBy(x => x.NomeProduto)
            .ProjectTo<ProdutoDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
