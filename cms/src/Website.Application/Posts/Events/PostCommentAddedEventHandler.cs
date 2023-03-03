using Website.Application.Common.Events;
using Website.Domain.Aggregates.Blog;
using Website.Domain.Contracts;
using Website.Domain.Events.Blog;

namespace Website.Application.Posts.Events;

internal sealed class PostCommentAddedEventHandler
    : IDomainEventHandler<PostCommentAddedEvent>
{
    // TODO : Adding Email Service here
    // private readonly IEmailServices _emailService;
    private readonly IUnitOfWork _uow;

    public PostCommentAddedEventHandler(/*IEmailServices emailService,*/ IUnitOfWork uow)
    {
        // _emailService = emailService ?? throw new KSArgumentNullException(nameof(emailService));
        _uow = uow ?? throw new KSArgumentNullException(nameof(uow));
    }

    public async Task Handle(PostCommentAddedEvent notification, CancellationToken cancellationToken)
    {
        Post post = await _uow.Posts.GetByIdAsync(notification.PostId, cancellationToken);
        if (post is null)
            return;
        var postComment = post.Comments.FirstOrDefault(pc => pc.Id == notification.CommentId);
        if(postComment is null)
            return;

        // await _emailService.SendPostCommentAddedNotificationAsync(post.Title.Value, postComment.Content.Value,
        //     notification.OccurredOn, cancellationToken);
    }
}