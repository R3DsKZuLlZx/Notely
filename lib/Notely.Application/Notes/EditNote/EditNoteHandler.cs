using FluentResults;
using MediatR;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.EditNote;

public class EditNoteHandler(INoteRepository noteRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<EditNoteCommand, Result>
{
    public async Task<Result> Handle(EditNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Id = request.Id,
            Title = request.Title,
            Content = request.Content,
        };

        await noteRepository.UpdateAsync(note, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
