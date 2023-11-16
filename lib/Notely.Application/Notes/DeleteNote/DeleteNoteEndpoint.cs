using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Notely.Application.Notes.DeleteNote;

public class DeleteNoteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
            "/api/notes/{id}", 
            async ([FromServices] ISender sender, Guid id) =>
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
            };

            await sender.Send(command);
            return Results.NoContent();
        }).Produces(204).WithName("DeleteNote");
    }
}
