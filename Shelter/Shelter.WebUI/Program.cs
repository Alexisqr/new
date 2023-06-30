using Domain.Entities;
using MediatR;

using Shelter.Application.Commands;
using Shelter.Application.Queries;

using Shelter.WebUI.Extenslons;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async(ctx,next) =>
   {
    try
    {
           await next();
    }
    catch (Exception)
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync("An error ocurred");
    }
} 
    );
app.UseHttpsRedirection();

app.RegisterEndpointDefinations();

app.Run();