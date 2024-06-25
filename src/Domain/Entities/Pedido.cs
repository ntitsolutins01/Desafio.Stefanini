namespace Desafio.Stefanini.Domain.Entities;

public class Pedido : BaseAuditableEntity
{
    public string? NomeCliente { get; set; }
    public string? EmailCliente { get; set; }
    public bool Pago { get; set; }
}
