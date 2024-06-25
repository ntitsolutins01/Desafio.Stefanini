using Desafio.Stefanini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Stefanini.Infrastructure.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(t => t.NomeProduto)
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(t => t.Valor)
            .HasPrecision(10,2)
            .IsRequired();
    }
}
