using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.EditNote;

public class EditNoteCommand : Command<bool>
{
    public required string FileName { get; set; }
    public required string Content { get; set; }
}
