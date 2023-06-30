
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;

namespace Shelter.WebUI.Filters
{
    public class GoodVallidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var good = context.GetArgument<ComentGood>(1);
            if (string.IsNullOrEmpty(good.Text)) return await Task.FromResult(Results.BadRequest("Coment not validate"));
        return await next(context);

                    }
    }
}
