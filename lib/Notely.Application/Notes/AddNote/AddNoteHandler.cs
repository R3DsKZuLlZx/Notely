using Foundatio.Storage;
using MediatR;
using Microsoft.Extensions.Logging;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.AddNote;

public class AddNoteHandler(ILogger<AddNoteHandler> logger, IFileRepository fileRepository)
    : IRequestHandler<AddNoteCommand, bool>
{
    public async Task<bool> Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(Note.Directory, $"{request.FileName}.txt");
        var exists = await fileRepository.Storage.ExistsAsync(filePath);
        if (!exists)
        {
            logger.LogInformation("File already exists at filepath: {FilePath}", filePath);
            return false;
        }
        
        logger.LogInformation("Saving file to filepath: {FilePath}", filePath);
        return await fileRepository.Storage.SaveFileAsync(filePath, request.Content);
    }
}
