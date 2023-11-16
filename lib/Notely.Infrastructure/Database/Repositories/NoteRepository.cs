using Microsoft.EntityFrameworkCore;
using Notely.Application.Notes;

namespace Notely.Infrastructure.Database.Repositories;

public class NoteRepository(ApplicationDbContext dbContext) : INoteRepository
{
    public async Task CreateAsync(Note note, CancellationToken cancellationToken)
    {
        await dbContext.Notes.AddAsync(note, cancellationToken);
    }

    public async Task<Note?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Notes.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Note note, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == note.Id, cancellationToken);
        if (entity is null)
        {
            return;
        }
        
        entity.Title = note.Title;
        entity.Content = note.Content;
        entity.Colour = note.Colour;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (entity is null)
        {
            return;
        }

        dbContext.Remove(entity);
    }
}
