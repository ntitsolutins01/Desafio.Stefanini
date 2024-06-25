using Desafio.Stefanini.Application.Common.Interfaces;

namespace Desafio.Stefanini.Application.Pedidos.Commands.DeletePedido;

public record DeletePedidoCommand(int Id) : IRequest;

public class DeletePedidoCommandHandler : IRequestHandler<DeletePedidoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePedidoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Pedidos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Pedidos.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
