using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Notely.Application.Notes.GetNotes;

public class GetNotesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/notes", async ([FromServices] ISender sender) =>
        {
            var query = new GetNotesQuery();
            var notes = await sender.Send(query);
            return Results.Ok(notes);
        });
    }
}
