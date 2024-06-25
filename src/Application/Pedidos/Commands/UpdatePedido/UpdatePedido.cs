using Desafio.Stefanini.Application.Common.Interfaces;

namespace Desafio.Stefanini.Application.Pedidos.Commands.UpdatePedido;

public record UpdatePedidoCommand : IRequest
{
    public int Id { get; init; }
    public string? NomeCliente { get; init; }
    public string? EmailCliente { get; init; }
    public bool Pago { get; init; }
}

public class UpdatePedidoCommandHandler : IRequestHandler<UpdatePedidoCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePedidoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Pedidos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.NomeCliente = request.NomeCliente;
        entity.EmailCliente = request.EmailCliente;
        entity.Pago = request.Pago;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
