namespace Notely.Application.Notes;

public interface INoteRepository
{
    Task CreateAsync(Note note, CancellationToken cancellationToken);

    Task<Note?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken);

    Task UpdateAsync(Note note, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
