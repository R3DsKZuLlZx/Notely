using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.AddNote;

public class AddNoteCommand : Command<bool>
{
    public required string FileName { get; set; }
    public required string Content { get; set; }
}
