using KSFramework.Primitives;

namespace Website.Domain.Events.Blog;

public sealed record PostCommentAddedEvent(Guid PostId, Guid CommentId) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}