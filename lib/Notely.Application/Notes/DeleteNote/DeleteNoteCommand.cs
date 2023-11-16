using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.DeleteNote;

public class DeleteNoteCommand : Command
{ 
    public required Guid Id { get; set; }
}
