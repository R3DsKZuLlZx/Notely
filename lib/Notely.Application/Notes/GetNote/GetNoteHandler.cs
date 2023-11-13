using MediatR;
using Microsoft.Extensions.Logging;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.GetNote;

public class GetNoteHandler(ILogger<GetNoteHandler> logger, IFileRepository fileRepository)
    : IRequestHandler<GetNoteQuery, Note?>
{
    public async Task<Note?> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(Note.Directory, $"{request.FileName}.txt");
        var exists = await fileRepository.Storage.ExistsAsync(filePath);
        if (!exists)
        {
            logger.LogInformation("File does not exist at filepath: {FilePath}", filePath);
            return null;
        }
        
        logger.LogInformation("Getting file content for filepath: {FilePath}", filePath);
        var stream = await fileRepository.Storage.GetFileStreamAsync(filePath, cancellationToken);
        var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync(cancellationToken);
        
        return new Note
        {
            FileName = request.FileName,
            Content = content,
        };
    }
}
