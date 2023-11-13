using MediatR;

namespace Notely.Application.Common.Cqrs;

public abstract class Command : IRequest
{
}

public abstract class Command<T> : IRequest<T>
{
}
