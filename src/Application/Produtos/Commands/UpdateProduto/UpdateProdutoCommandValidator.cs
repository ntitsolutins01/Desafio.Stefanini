namespace Desafio.Stefanini.Application.Produtos.Commands.UpdateProduto;

public class UpdateProdutoCommandValidator : AbstractValidator<UpdateProdutoCommand>
{
    public UpdateProdutoCommandValidator()
    {
        RuleFor(v => v.NomeProduto)
            .MaximumLength(20)
            .NotEmpty();
        RuleFor(v => v.Valor)
            .NotEmpty();
    }
}
