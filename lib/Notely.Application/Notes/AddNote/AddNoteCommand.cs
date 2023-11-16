using FluentResults;
using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.AddNote;

public class AddNoteCommand : Command<Result>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
}
