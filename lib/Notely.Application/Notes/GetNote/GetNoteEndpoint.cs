using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Notely.Application.Notes.GetNote;

public class GetNoteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/notes/{fileName}", async ([FromServices] ISender sender, string fileName) =>
        {
            var query = new GetNoteQuery
            {
                FileName = fileName,
            };

            var note = await sender.Send(query);
            if (note is null)
            {
                return Results.BadRequest();
            }
            
            return Results.Ok(note);
        });
    }
}
