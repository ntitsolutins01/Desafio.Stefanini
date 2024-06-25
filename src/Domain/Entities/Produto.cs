using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Stefanini.Domain.Entities;

public class Produto : BaseAuditableEntity
{
    public string? NomeProduto { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Valor { get; set; }
}
