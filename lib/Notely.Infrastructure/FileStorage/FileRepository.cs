using Foundatio.Storage;
using Notely.Application.Common.Interfaces;

namespace Notely.Infrastructure.FileStorage;

public class FileRepository(IFileStorage storage) : IFileRepository
{
    public IFileStorage Storage { get; } = storage;
}
