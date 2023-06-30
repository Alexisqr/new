
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Shelter.WebUI.Filters
{
    public class GlobVallidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var glob = context.GetArgument<ComentGlob>(1);
            if (string.IsNullOrEmpty(glob.Text)) return await Task.FromResult(Results.BadRequest("Coment not validate"));
        return await next(context);

                    }
    }
}
