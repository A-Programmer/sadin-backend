using System.Runtime.Serialization;
using KSFramework.Primitives;
using Website.Domain.Aggregates.Blog.ValueObjects;

namespace Website.Domain.Aggregates.Blog;

[Serializable]
public sealed class Keyword : EntityWithSoftDelete, ISerializable
{
    public PostKeywordTitle Title { get; private set; }
    public PostKeywordName Name { get; private set; }
    
    public PostKeywordSlug Slug { get; private set; }

    public IReadOnlyCollection<Post> Posts => _posts;
    protected List<Post> _posts = new();

    public Keyword(Guid id, PostKeywordTitle title, PostKeywordName name)
        : base(id)
    {
        Title = title ?? throw new KSArgumentNullException($"{nameof(title)}");
        Name = name ?? PostKeywordName.Create(title.Value);
        Slug = PostKeywordSlug.Create(name?.Value ?? title.Value);
    }

    public static Keyword Create(PostKeywordTitle title, PostKeywordName name) =>
        new(Guid.NewGuid(), title, name);

    public void Update(PostKeywordTitle title, PostKeywordName name, bool updateSlug = false)
    {
        Title = title ?? throw new KSArgumentNullException($"{nameof(title)}");
        Name = name ?? PostKeywordName.Create(title.Value);
        if (updateSlug) Slug = PostKeywordSlug.Create(name?.Value ?? title.Value);
    }

    protected Keyword(Guid id)
        : base(id)
    {
    }

    #region Serialization
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Title), Title);
        info.AddValue(nameof(Name), Name);
        info.AddValue(nameof(Slug), Slug);
        info.AddValue(nameof(Posts), Posts);
    }
    #endregion
}