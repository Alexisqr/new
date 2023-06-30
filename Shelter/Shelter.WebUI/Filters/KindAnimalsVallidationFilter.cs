
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Shelter.WebUI.Filters
{
    public class KindAnimalsVallidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var kindAnimals = context.GetArgument<ComentKindAnimals>(1);
            if (string.IsNullOrEmpty(kindAnimals.Text)) return await Task.FromResult(Results.BadRequest("Coment not validate"));
        return await next(context);

                    }
    }
}
