using KSFramework.Primitives;

namespace Website.Domain.Events.Blog;

public sealed record RepliedToPostCommentEvent(Guid PostId, Guid ParentCommentId, Guid ChildCommentId) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}