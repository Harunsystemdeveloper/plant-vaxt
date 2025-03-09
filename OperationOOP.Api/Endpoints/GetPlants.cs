using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OperationOOP.Core.Data;

namespace OperationOOP.Api.Endpoints

    {
        // Detta är endpoint för att hämta alla växter
    public class GetPlants : IEndpoint
    {
        // Detta beskriver API-routen och kopplar den till metoden Handle
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/plants", Handle)
            .WithSummary("Get all plants");

           // Detta är en modell  som returnerar information om växter
        public record Response(
            int Id,
            string Name,
            string Species,
            string CareLevel
        );


// Detta hämtar alla växter från databasen och returnerar dem som en lista
        private static List<Response> Handle(IDatabase db)
        {
            return db.Plants.Select(plant => new Response(
                Id: plant.Id,
                Name: plant.Name,
                Species: plant.Species,
                CareLevel: plant.CareLevel
            )).ToList();
        }
    }

    public class GetPlant : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/plants/{id}", Handle)
            .WithSummary("Get a plant by ID");

        public record Request(int Id);

        // Detta är en respons modell  som returnerar information om en specifik växt

        public record Response(
            int Id,
            string Name,
            string Species,
            string CareLevel
        );

        private static IResult Handle([AsParameters] Request request, IDatabase db)
        {
            var plant = db.Plants.Find(p => p.Id == request.Id);
            if (plant == null)
            {
                return Results.NotFound(new { Message = "Plant not found" });
            }

            return Results.Ok(new Response(
                Id: plant.Id,
                Name: plant.Name,
                Species: plant.Species,
                CareLevel: plant.CareLevel
            ));
        }
    }
}