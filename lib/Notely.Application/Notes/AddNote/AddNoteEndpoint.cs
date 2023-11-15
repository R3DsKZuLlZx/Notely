using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Notely.Application.Notes.AddNote;

public class AddNoteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/notes", 
            async ([FromServices] ISender sender, [FromBody] AddNoteCommand command) =>
            {
                var result = await sender.Send(command);
                if (!result)
                {
                    return Results.BadRequest();
                }
                
                return Results.Created();
        }).Produces(201).Produces(400).WithName("AddNote");
    }
}
