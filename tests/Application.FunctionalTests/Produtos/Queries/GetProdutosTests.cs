using Desafio.Stefanini.Application.Produtos.Queries.GetProdutosWithPagination;

namespace Desafio.Stefanini.Application.FunctionalTests.Produtos.Queries;

using static Testing;

public class GetProdutosTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnProdutos()
    {
        await RunAsDefaultUserAsync();

        var query = new GetProdutosWithPaginationQuery();

        var result = await SendAsync(query);

        result.Items.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetProdutosWithPaginationQuery();

        var action = () => SendAsync(query);
        
        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
