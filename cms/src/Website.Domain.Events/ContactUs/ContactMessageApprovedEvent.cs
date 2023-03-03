using KSFramework.Primitives;

namespace Website.Domain.Events.ContactUs;

public sealed record ContactMessageApprovedEvent(Guid MessageId, string Title, string MessageContent) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}