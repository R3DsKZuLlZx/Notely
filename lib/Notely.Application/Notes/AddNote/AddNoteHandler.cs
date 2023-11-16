using FluentResults;
using MediatR;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.AddNote;

public class AddNoteHandler(INoteRepository noteRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<AddNoteCommand, Result>
{
    public async Task<Result> Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Title = request.Title,
            Content = request.Content,
        };

        await noteRepository.CreateAsync(note, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
