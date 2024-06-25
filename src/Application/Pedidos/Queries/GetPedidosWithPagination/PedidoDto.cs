using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.Pedidos.Queries.GetPedidosWithPagination;

public class PedidoDto
{
    public int Id { get; init; }
    public string? NomeCliente { get; init; }
    public string? EmailCliente { get; init; }
    public bool Pago { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Pedido, PedidoDto>();
        }
    }
}
