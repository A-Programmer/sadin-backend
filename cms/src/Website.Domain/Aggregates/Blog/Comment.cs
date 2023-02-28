using System.Runtime.Serialization;
using KSFramework.Primitives;
using Website.Domain.Aggregates.Blog.ValueObjects;

namespace Website.Domain.Aggregates.Blog;


[Serializable]
public sealed class Comment : EntityWithSoftDelete, ISerializable
{
    public PostCommentContent Content { get; private set; }
    public bool IsApproved { get; private set; }
    public bool IsChecked { get; private set; }

    public DateTimeOffset? CheckedDate { get; private set; }

    private List<Comment> _replies = new();
    public IReadOnlyCollection<Comment> Replies => _replies.AsReadOnly();

    public Guid? ParentId { get; private set; }
    public Comment Parent { get; protected set; }

    public Guid PostId { get; private set; }
    public Post Post { get; protected set; }

    public Comment(Guid id, PostCommentContent content, bool isApproved)
        : base(id)
    {
        Content = content ?? throw new KSArgumentNullException($"{nameof(content)}");
        IsApproved = isApproved;
    }

    public static Comment Create(PostCommentContent content, bool isApproved) =>
        new(Guid.NewGuid(), content, isApproved);


    protected Comment(Guid id)
        : base(id)
    {
        
    }

    public Comment SetParentId(Guid? parentId)
    {
        ParentId = parentId;
        return this;
    }

    public Comment SetPostId(Guid postId)
    {
        PostId = postId;
        return this;
    }

    public void AddReply(Comment reply) => _replies.Add(reply);

    public Comment ChangeApproveStatus(bool isApproved)
    {
        IsApproved = isApproved;
        return this;
    }

    public Comment Approve()
    {
        IsApproved = true;
        return this;
    }

    public Comment Reject()
    {
        IsApproved = false;
        return this;
    }

    public Comment ChangeCheckStatus(bool newCheckStatus)
    {
        IsChecked = newCheckStatus;
        return this;
    }

    public Comment Checked()
    {
        IsChecked = true;
        return this;
    }

    public Comment NotChecked()
    {
        IsChecked = false;
        return this;
    }

    public void SetReplies(List<Comment> postComment) => _replies = postComment;
    
    
    #region Serialization

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Id), Id);
        info.AddValue(nameof(Content), Content);
        info.AddValue(nameof(IsApproved), IsApproved);
        info.AddValue(nameof(IsChecked), IsChecked);
        info.AddValue(nameof(ParentId), ParentId);
        info.AddValue(nameof(Parent ), Parent);
        info.AddValue(nameof(PostId), PostId);
        info.AddValue(nameof(Replies ), Replies);
    }
    #endregion
}

    