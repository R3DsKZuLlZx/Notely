﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Notely.Application.Notes.EditNote;

public class EditNoteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/api/notes", 
            async ([FromServices] ISender sender, [FromBody] EditNoteCommand command) =>
            {
                var result = await sender.Send(command);
                if (!result.IsSuccess)
                {
                    return Results.BadRequest();
                }
                
                return Results.Ok();
        }).Produces(200).Produces(400).WithName("EditNote");
    }
}
