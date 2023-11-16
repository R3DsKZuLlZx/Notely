using FluentResults;
using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.GetNote;

public class GetNoteQuery : Query<Result<Note>>
{
    public required Guid Id { get; set; }
}
