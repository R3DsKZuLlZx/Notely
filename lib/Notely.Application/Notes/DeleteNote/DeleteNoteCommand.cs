using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.DeleteNote;

public class DeleteNoteCommand : Command<bool>
{ 
    public required string FileName { get; set; }
}
