using FluentResults;
using Notely.Application.Common.Cqrs;

namespace Notely.Application.Notes.GetNotes;

public class GetNotesQuery : Query<Result<List<Note>>>
{
}
