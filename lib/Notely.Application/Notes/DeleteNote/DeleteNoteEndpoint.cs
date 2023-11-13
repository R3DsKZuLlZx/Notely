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
            "/notes/{fileName}", 
            async ([FromServices] ISender sender, string fileName) =>
        {
            var command = new DeleteNoteCommand
            {
                FileName = fileName,
            };

            await sender.Send(command);
            return Results.NoContent();
        });
    }
}
