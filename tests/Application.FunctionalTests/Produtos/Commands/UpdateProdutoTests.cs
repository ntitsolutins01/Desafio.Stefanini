using Desafio.Stefanini.Application.Common.Exceptions;
using Desafio.Stefanini.Application.Produtos.Commands.CreateProduto;
using Desafio.Stefanini.Application.Produtos.Commands.UpdateProduto;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.FunctionalTests.Produtos.Commands;

using static Testing;

public class UpdateProdutoTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidProdutoId()
    {
        var command = new UpdateProdutoCommand { Id = 99, NomeProduto = "Lapis" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        var produtoId = await SendAsync(new CreateProdutoCommand
        {
            NomeProduto = "Borracha"
        });

        await SendAsync(new CreateProdutoCommand
        {
            NomeProduto = "Grafite",
            Valor = 5
        });

        var command = new UpdateProdutoCommand
        {
            Id = produtoId,
            NomeProduto = "Borracha",
            Valor = 3
        };

        (await FluentActions.Invoking(() =>
            SendAsync(command))
                .Should().ThrowAsync<ValidationException>().Where(ex => ex.Errors.ContainsKey("Nome Produto")))
                .And.Errors["Title"].Should().Contain("'Nome Produto' deve ser unico.");
    }

    [Test]
    public async Task ShouldUpdateProduto()
    {
        var userId = await RunAsDefaultUserAsync();

        var produtoId = await SendAsync(new CreateProdutoCommand
        {
            NomeProduto = "Caderno"
        });

        var command = new UpdateProdutoCommand
        {
            Id = produtoId,
            NomeProduto = "Agenda"
        };

        await SendAsync(command);

        var list = await FindAsync<Produto>(produtoId);

        list.Should().NotBeNull();
        list!.NomeProduto.Should().Be(command.NomeProduto);
        list.LastModifiedBy.Should().NotBeNull();
        list.LastModifiedBy.Should().Be(userId);
        list.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
