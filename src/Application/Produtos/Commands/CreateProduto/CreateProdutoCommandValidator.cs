namespace Desafio.Stefanini.Application.Produtos.Commands.CreateProduto;

public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    public CreateProdutoCommandValidator()
    {
        RuleFor(v => v.NomeProduto)
            .MaximumLength(20)
            .NotEmpty();
        RuleFor(v => v.Valor)
            .NotEmpty();
    }
}
