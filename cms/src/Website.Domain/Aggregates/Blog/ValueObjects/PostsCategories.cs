using System.Runtime.Serialization;
using KSFramework.Primitives;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

[Serializable]
public class PostsCategories : ValueObject, ISerializable
{
    public PostsCategories(Guid postId, Guid categoryId)
    {
        PostId = postId;
        CategoryId = categoryId;
    }

    protected PostsCategories()
    {
    }

    public Guid PostId { get; private set; }

    public Guid CategoryId { get; private set; }


    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(PostId), PostId);
        info.AddValue(nameof(CategoryId), CategoryId);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PostId;
        yield return CategoryId;
    }
}
