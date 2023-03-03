using KSFramework.Primitives;

namespace Website.Domain.Events.ContactUs;

public sealed record ContactMessageSentEvent(Guid MessageId, string Title, string MessageContent) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}