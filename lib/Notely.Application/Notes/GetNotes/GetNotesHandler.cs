using FluentResults;
using MediatR;

namespace Notely.Application.Notes.GetNotes;

public class GetNotesHandler(INoteRepository noteRepository)
    : IRequestHandler<GetNotesQuery, Result<List<Note>>>
{
    public async Task<Result<List<Note>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await noteRepository.GetAllAsync(cancellationToken);
        return Result.Ok(notes.ToList());
    }
}
