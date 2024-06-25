namespace Desafio.Stefanini.Application.Pedidos.Commands.CreatePedido;

public class CreatePedidoCommandValidator : AbstractValidator<CreatePedidoCommand>
{
    public CreatePedidoCommandValidator()
    {
        RuleFor(v => v.NomeCliente)
            .MaximumLength(60)
            .NotEmpty();
        RuleFor(v => v.EmailCliente)
            .MaximumLength(60)
            .NotEmpty();
    }
}
