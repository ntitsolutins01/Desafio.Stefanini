using Desafio.Stefanini.Application.Common.Exceptions;
using Desafio.Stefanini.Application.Produtos.Commands.CreateProduto;
using Desafio.Stefanini.Domain.Entities;

namespace Desafio.Stefanini.Application.FunctionalTests.Produtos.Commands;

using static Testing;

public class CreateProdutoTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateProdutoCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        await SendAsync(new CreateProdutoCommand
        {
            NomeProduto = "Arroz"
        });

        var command = new CreateProdutoCommand
        {
            NomeProduto = "Feijao"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateProduto()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateProdutoCommand
        {
            NomeProduto = "Milho"
        };

        var id = await SendAsync(command);

        var list = await FindAsync<Produto>(id);

        list.Should().NotBeNull();
        list!.NomeProduto.Should().Be(command.NomeProduto);
        list.CreatedBy.Should().Be(userId);
        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
