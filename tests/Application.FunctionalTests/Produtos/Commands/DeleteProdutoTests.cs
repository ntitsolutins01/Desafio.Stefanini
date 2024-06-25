using Desafio.Stefanini.Application.Produtos.Commands.CreateProduto;
using Desafio.Stefanini.Application.Produtos.Commands.DeleteProduto;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.FunctionalTests.Produtos.Commands;

using static Testing;

public class DeleteProdutoTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidProdutoId()
    {
        var command = new DeleteProdutoCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteProduto()
    {
        var produtoId = await SendAsync(new CreateProdutoCommand
        {
            NomeProduto = "Caneta",
            Valor = (decimal?)1.20
        });

        await SendAsync(new DeleteProdutoCommand(produtoId));

        var list = await FindAsync<Produto>(produtoId);

        list.Should().BeNull();
    }
}
