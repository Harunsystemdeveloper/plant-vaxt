﻿namespace OperationOOP.Api.Endpoints;
public class GetBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/{id}", Handle)
        .WithSummary("Bonsai trees");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var bonsai = db.Bonsais.Find(bonsai => bonsai.Id == request.Id);

        // map bonsai to response dto
        var response = new Response(
            Id: bonsai.Id,
            Name: bonsai.Name,
            Species: bonsai.Species,
            AgeYears: bonsai.AgeYears,
            LastWatered: bonsai.LastWatered,
            LastPruned: bonsai.LastPruned,
            Style: bonsai.Style,
            CareLevel: bonsai.CareLevel
            );

        return response;
    }
}