using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationOOP.Api.Endpoints
{
   public class CreatePlant : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/plants", Handle)
            .WithSummary("Create a new plant");

        public record Request(
            string Name,
            string Species,
            string CareLevel
        );

        public record Response(int Id);

        private static async Task<IResult> Handle(Request request, IDatabase db)
        {
            var plant = new Plant
            {
                Id = db.Plants.Any() ? db.Plants.Max(p => p.Id) + 1 : 1,
                Name = request.Name,
                Species = request.Species,
                CareLevel = request.CareLevel
            };

            db.Plants.Add(plant);

            return Results.Created($"/plants/{plant.Id}", new Response(plant.Id));
        }
    }
}