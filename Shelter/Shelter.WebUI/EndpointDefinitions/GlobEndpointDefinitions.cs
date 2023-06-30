using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
using Shelter.Application.Commands;
using Shelter.Application.Queries;
using Shelter.WebUI.Abstractions;
using Shelter.WebUI.Filters;

namespace Shelter.WebUI.EndpointDefinitions
{
    public class GlobEndpointDefinitions : IEnpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var comentglob = app.MapGroup("/api/comentglob");

            comentglob.MapGet("/{id}", GetComentGlobById).WithName("GetComentGlobById");
            comentglob.MapPost("/", CreateComentGlob)
                .AddEndpointFilter<GlobVallidationFilter>();
            comentglob.MapGet("/", GetAllComentGlob);
            comentglob.MapPut("/{id}", UpdateComentGlob)
                .AddEndpointFilter<GlobVallidationFilter>();
            comentglob.MapDelete("/{id}", DeleteComentGlob);

        }
        private async Task<IResult> GetComentGlobById(IMediator mediator, int id)
        {
            var getComentglob = new GetComentGlobById { ComentGlobId = id };
            var _comentglob = await mediator.Send(getComentglob);
            return TypedResults.Ok(_comentglob);
        }
        private async Task<IResult> CreateComentGlob(IMediator mediator, ComentGlob comentGlob)
        {
            var createComentGlob = new CreateComentGlob { ComentGlobText = comentGlob.Text };
            var createdComentGlob = await mediator.Send(createComentGlob);
            return Results.CreatedAtRoute("GetComentGlobById", new { createdComentGlob.Id }, createdComentGlob);

        }
        private async Task<IResult> GetAllComentGlob(IMediator mediator)
        {
            var getComentglob = new GetAllComentGlob();
            var _comentglob = await mediator.Send(getComentglob);
            return TypedResults.Ok(_comentglob);
        }
        private async Task<IResult> UpdateComentGlob(IMediator mediator, ComentGlob comentGlob, int id)
        {
            var updateComentglob = new UpdateComentGlob { ComentGlobId = id, ComentGlobText = comentGlob.Text };
            var updatedComentglob = await mediator.Send(updateComentglob);
            return TypedResults.Ok(updatedComentglob);
        }
        private async Task<IResult> DeleteComentGlob(IMediator mediator, int id)
        {
            var deleteComentglob = new DeleteComentGlob { ComentGlobId = id };
            var deletedComentglob = await mediator.Send(deleteComentglob);
            return TypedResults.NoContent();
        }
    }
}
