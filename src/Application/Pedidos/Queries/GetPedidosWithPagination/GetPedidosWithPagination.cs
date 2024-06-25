using Desafio.Stefanini.Application.Common.Interfaces;
using Desafio.Stefanini.Application.Common.Mappings;
using Desafio.Stefanini.Application.Common.Models;

namespace Desafio.Stefanini.Application.Pedidos.Queries.GetPedidosWithPagination;

public record GetPedidosWithPaginationQuery : IRequest<PaginatedList<PedidoDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPedidosWithPaginationQueryHandler : IRequestHandler<GetPedidosWithPaginationQuery, PaginatedList<PedidoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPedidosWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PedidoDto>> Handle(GetPedidosWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Pedidos
            .OrderBy(x => x.NomeCliente)
            .ProjectTo<PedidoDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
