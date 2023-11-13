using Foundatio.Storage;

namespace Notely.Application.Common.Interfaces;

public interface IFileRepository
{
    public IFileStorage Storage { get; }
}
