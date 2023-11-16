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
        app.MapGet("/api/notes/{id}", async ([FromServices] ISender sender, Guid id) =>
        {
            var query = new GetNoteQuery
            {
                Id = id,
            };

            var result = await sender.Send(query);
            if (!result.IsSuccess)
            {
                return Results.BadRequest();
            }
            
            return Results.Ok(result.Value);
        }).Produces<Note>().Produces(400).WithName("GetNote");
    }
}
