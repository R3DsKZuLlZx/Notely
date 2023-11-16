using FluentResults;
using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.EditNote;

public class EditNoteCommand : Command<Result>
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
}
