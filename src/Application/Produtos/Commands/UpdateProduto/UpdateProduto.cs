using Desafio.Stefanini.Application.Common.Interfaces;

namespace Desafio.Stefanini.Application.Produtos.Commands.UpdateProduto;

public record UpdateProdutoCommand : IRequest
{
    public int Id { get; init; }
    public string? NomeProduto { get; init; }
    public decimal? Valor { get; init; }
}

public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProdutoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Produtos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.NomeProduto = request.NomeProduto;
        entity.Valor = request.Valor;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
