using Desafio.Stefanini.Infrastructure.Identity;

namespace Desafio.Stefanini.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
