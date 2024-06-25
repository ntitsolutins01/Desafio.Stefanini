namespace Desafio.Stefanini.Application.Pedidos.Commands.UpdatePedido;

public class UpdatePedidoCommandValidator : AbstractValidator<UpdatePedidoCommand>
{
    public UpdatePedidoCommandValidator()
    {
        RuleFor(v => v.NomeCliente)
            .MaximumLength(60)
            .NotEmpty();
        RuleFor(v => v.EmailCliente)
            .MaximumLength(60)
            .NotEmpty();
    }
}
