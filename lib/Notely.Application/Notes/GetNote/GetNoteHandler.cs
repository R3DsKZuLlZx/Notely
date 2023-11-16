using FluentResults;
using MediatR;

namespace Notely.Application.Notes.GetNote;

public class GetNoteHandler(INoteRepository noteRepository)
    : IRequestHandler<GetNoteQuery, Result<Note>>
{
    public async Task<Result<Note>> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetAsync(request.Id, cancellationToken);
        if (note is null)
        {
            return Result.Fail<Note>($"No note exists with id {request.Id}");
        }

        return Result.Ok(note);
    }
}
