using System.Runtime.Serialization;
using KSFramework.Primitives;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

[Serializable]
public sealed class View : ValueObject, ISerializable
{
    public DateTime ViewDate { get; private set; }
    public PostViewUserIp UserIp { get; private set; }
    public Guid PostId { get; private set; }

    private View(PostViewUserIp userIp, Guid postId)
    {
        ViewDate = DateTime.UtcNow;
        UserIp = userIp;
        PostId = postId;
    }

    public static View Create(PostViewUserIp userIp, Guid postId) => new(userIp, postId);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ViewDate;
    }

    protected View()
    {
        
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(ViewDate), ViewDate);
        info.AddValue(nameof(UserIp), UserIp);
        info.AddValue(nameof(PostId), PostId);
    }
}