using Desafio.Stefanini.Application.Common.Interfaces;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.Produtos.Commands.CreateProduto;

public record CreateProdutoCommand : IRequest<int>
{
    public string? NomeProduto { get; init; }
    public decimal? Valor { get; set; }
}

public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProdutoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Produto
        {
            NomeProduto = request.NomeProduto,
            Valor = request.Valor
        };

        _context.Produtos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
