
    using Domain.Entities;
    using global::Shelter.Application.Commands;
    using global::Shelter.Application.Queries;
    using global::Shelter.WebUI.Abstractions;
    using MediatR;
    using Microsoft.AspNetCore.Http.Metadata;
using Shelter.WebUI.Filters;

    namespace Shelter.WebUI.EndpointDefinitions
    {
        public class GoodEndpointDefinitions : IEnpointDefinition
        {
            public void RegisterEndpoints(WebApplication app)
            {
            var comentgood = app.MapGroup("/api/comentgood");

            comentgood.MapGet("/{id}", GetComentGoodById).WithName("GetComentGoodById");
            comentgood.MapPost("/", CreateComentGood)
                 .AddEndpointFilter<GoodVallidationFilter>(); 
            comentgood.MapGet("/", GetAllComentGood);
            comentgood.MapPut("/{id}", UpdateComentGood)
                .AddEndpointFilter<GoodVallidationFilter>();
            comentgood.MapDelete("/{id}", DeleteComentGood);


            }
        private async Task<IResult> GetComentGoodById(IMediator mediator, int id)
        {
            var getComentgood = new GetComentGoodById { ComentGoodId = id };
            var _comentgood = await mediator.Send(getComentgood);
            return TypedResults.Ok(_comentgood);
        }
        private async Task<IResult> CreateComentGood(IMediator mediator, ComentKindAnimals comentGood)
        {
            var createComentGood = new CreateComentGood { ComentGoodText = comentGood.Text };
            var createdComentGood = await mediator.Send(createComentGood);
            return Results.CreatedAtRoute("GetComentGoodById", new { createdComentGood.Id }, createdComentGood);

        }
        private async Task<IResult> GetAllComentGood(IMediator mediator)
        {
            var getComentgood = new GetAllComentGood();
            var _comentgood = await mediator.Send(getComentgood);
            return TypedResults.Ok(_comentgood);
        }
        private async Task<IResult> UpdateComentGood(IMediator mediator, ComentGood comentGood, int id)
        {
            var updateComentgood = new UpdateComentGood { ComentGoodId = id, ComentGoodText = comentGood.Text };
            var updatedComentgood = await mediator.Send(updateComentgood);
            return TypedResults.Ok(updatedComentgood);
        }
        private async Task<IResult> DeleteComentGood(IMediator mediator, int id)
        {
            var deleteComentGood = new DeleteComentGood { ComentGoodId = id };
            var deletedComentGood = await mediator.Send(deleteComentGood);
            return TypedResults.NoContent();
        }
    }
    }


