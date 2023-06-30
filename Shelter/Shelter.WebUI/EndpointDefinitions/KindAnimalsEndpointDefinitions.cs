using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
using Shelter.Application.Commands;
using Shelter.Application.Queries;
using Shelter.WebUI.Abstractions;
using Shelter.WebUI.Filters;

namespace Shelter.WebUI.EndpointDefinitions
{
    public class KindAnimalsEndpointDefinitions : IEnpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var comentkindanimals = app.MapGroup("/api/comentkindanimals");

            comentkindanimals.MapGet("/{id}",GetComentKindAnimalsById).WithName("GetComentKindAnimalsById");
            comentkindanimals.MapPost("/", CreateComentKindAnimals)
                .AddEndpointFilter<KindAnimalsVallidationFilter>();
            comentkindanimals.MapGet("/", GetAllComentKindAnimals);
            comentkindanimals.MapPut("/{id}", UpdateComentKindAnimals)
                .AddEndpointFilter<KindAnimalsVallidationFilter>();
            comentkindanimals.MapDelete("/{id}", DeleteComentKindAnimals);

        }
        private async Task <IResult> GetComentKindAnimalsById (IMediator mediator , int id)
        {
            var getComentkindanimals = new GetComentKindAnimalsById { ComentKindAnimalsId = id };
            var _comentkindanimals = await mediator.Send(getComentkindanimals);
            return TypedResults.Ok(_comentkindanimals);
        }
        private async Task<IResult> CreateComentKindAnimals(IMediator mediator, ComentKindAnimals comentKindAnimals)
        {
            var createComentKindAnimals = new CreateComentKindAnimals { ComentKindAnimalsText = comentKindAnimals.Text };
            var createdComentKindAnimals = await mediator.Send(createComentKindAnimals);
            return Results.CreatedAtRoute("GetComentKindAnimalsById", new { createdComentKindAnimals.Id }, createdComentKindAnimals);

        }
        private async Task<IResult> GetAllComentKindAnimals(IMediator mediator)
        {
            var getComentkindAnimals = new GetAllComentKindAnimals();
            var _comentkindAnimals = await mediator.Send(getComentkindAnimals);
            return TypedResults.Ok(_comentkindAnimals);
        }
        private async Task<IResult> UpdateComentKindAnimals(IMediator mediator, ComentKindAnimals comentKindAnimals, int id)
        {
            var updateComentKindAnimals = new UpdateComentKindAnimals { ComentKindAnimalsId = id, ComentKindAnimalsText = comentKindAnimals.Text };
            var updatedComentKindAnimals = await mediator.Send(comentKindAnimals);
            return TypedResults.Ok(updatedComentKindAnimals);
        }
        private async Task<IResult> DeleteComentKindAnimals(IMediator mediator, int id)
        {
            var deleteComentKindAnimals = new DeleteComentKindAnimals { ComentKindAnimalsId = id };
            var deletedComentKindAnimals = await mediator.Send(deleteComentKindAnimals);
            return TypedResults.NoContent();
        }
    }
}
