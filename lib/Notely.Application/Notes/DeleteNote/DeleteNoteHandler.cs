using MediatR;
using Microsoft.Extensions.Logging;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.DeleteNote;

public class DeleteNoteHandler(ILogger<DeleteNoteHandler> logger, IFileRepository fileRepository) 
    : IRequestHandler<DeleteNoteCommand, bool>
{
    public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(Note.Directory, $"{request.FileName}.txt");
        logger.LogInformation("Deleting file from {FilePath}", filePath);
        return await fileRepository.Storage.DeleteFileAsync(filePath, cancellationToken);
    }
}
