using Desafio.Stefanini.Application.Common.Interfaces;

namespace Desafio.Stefanini.Application.Produtos.Commands.DeleteProduto;

public record DeleteProdutoCommand(int Id) : IRequest;

public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProdutoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Produtos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Produtos.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
