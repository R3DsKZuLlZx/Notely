using Foundatio.Storage;
using MediatR;
using Notely.Application.Common.Interfaces;

namespace Notely.Application.Notes.GetNotes;

public class GetNotesHandler(IFileRepository fileRepository)
    : IRequestHandler<GetNotesQuery, List<Note>>
{
    public async Task<List<Note>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var files = await fileRepository.Storage.GetFileListAsync(cancellationToken: cancellationToken);
        var notes = new List<Note>();
        
        foreach (var file in files)
        {
            var stream = await fileRepository.Storage.GetFileStreamAsync(file.Path, cancellationToken);
            var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync(cancellationToken);

            var note = new Note
            {
                FileName = file.Path[(Note.Directory.Length + 1)..],
                Content = content,
            };
            notes.Add(note);
        }

        return notes;
    }
}
