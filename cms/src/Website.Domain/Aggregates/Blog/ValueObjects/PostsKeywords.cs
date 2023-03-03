using System.Runtime.Serialization;
using KSFramework.Primitives;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

[Serializable]
public class PostsKeywords : ValueObject, ISerializable
{
    public PostsKeywords(Guid postId, Guid keywordId)
    {
        PostId = postId;
        KeywordId = keywordId;
    }
    protected PostsKeywords()
    {
    }

    public Guid PostId { get; private set; }
    public Guid KeywordId { get; private set; }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(PostId), PostId);
        info.AddValue(nameof(KeywordId), KeywordId);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PostId;
        yield return KeywordId;
    }
}