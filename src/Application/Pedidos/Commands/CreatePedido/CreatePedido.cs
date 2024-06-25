using Desafio.Stefanini.Application.Common.Interfaces;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;

public record CreatePedidoCommand : IRequest<int>
{
    public string? NomeCliente { get; init; }
    public string? EmailCliente { get; init; }
    public bool Pago { get; init; }
}

public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePedidoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Pedido
        {
            NomeCliente = request.NomeCliente,
            EmailCliente = request.EmailCliente,
            Pago = request.Pago
        };

        _context.Pedidos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
