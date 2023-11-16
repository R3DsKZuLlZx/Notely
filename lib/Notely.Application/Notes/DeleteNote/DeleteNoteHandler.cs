using MediatR;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.DeleteNote;

public class DeleteNoteHandler(INoteRepository noteRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteNoteCommand>
{
    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        await noteRepository.DeleteAsync(request.Id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
