using KSFramework.Primitives;

namespace Website.Domain.Events.Blog;

public sealed record PostPublishedEvent(Guid PostId) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}