using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.GetNote;

public class GetNoteQuery : Query<Note?>
{
    public required string FileName { get; set; }
}
