using MediatR;
using Microsoft.EntityFrameworkCore;
using Shelter.Application.Abstractions;
using Shelter.Application.Commands;
using Shelter.Infrastructure.Repositoties;
using Shelter.Infrastructure;
using Microsoft.AspNetCore.Http.Metadata;
using Shelter.WebUI.Abstractions;

namespace Shelter.WebUI.Extenslons
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
          
            var cs = builder.Configuration.GetConnectionString("Defaut");
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ComentDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IComentGlobRepository, ComentGlobRepository>();
            builder.Services.AddScoped<IComentGoodRepository, ComentGoodRepository>();
            builder.Services.AddScoped<IComentKindAnimalsRepository, ComentKindOfAnimalsRepository>();
            builder.Services.AddMediatR(typeof(CreateComentGlob));
            builder.Services.AddMediatR(typeof(CreateComentGood));
            builder.Services.AddMediatR(typeof(CreateComentKindAnimals));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
        public static void RegisterEndpointDefinations(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEnpointDefinition))
                && !t.IsAbstract && !t.IsInterface )
                .Select(Activator.CreateInstance)
                .Cast<IEnpointDefinition>();
            foreach (var endpointDef in endpointDefinitions)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
    }
}
