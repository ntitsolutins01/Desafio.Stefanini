using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Pedido> Pedidos { get; }

    DbSet<Produto> Produtos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
