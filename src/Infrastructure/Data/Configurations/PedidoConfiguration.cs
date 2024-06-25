using Desafio.Stefanini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Stefanini.Infrastructure.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.Property(t => t.NomeCliente)
            .HasMaxLength(60)
            .IsRequired();
        builder.Property(t => t.EmailCliente)
            .HasMaxLength(60)
            .IsRequired();
    }
}
