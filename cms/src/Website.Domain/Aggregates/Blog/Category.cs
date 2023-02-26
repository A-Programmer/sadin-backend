using System.Runtime.Serialization;
using KSFramework.Primitives;
using Website.Domain.Aggregates.Blog.ValueObjects;

namespace Website.Domain.Aggregates.Blog;

[Serializable]
public sealed class Category : EntityWithSoftDelete, ISerializable
{
    private Category(Guid id, PostCategoryTitle title, PostCategoryName name, PostCategoryDescription description) 
        : base(id)
    {
        Title = title ?? throw new KSArgumentNullException(nameof(title));
        Name = name ?? throw new KSArgumentNullException(nameof(name));
        Slug = PostCategorySlug.Create(name.Value);
        Description = description;
    }

    public static Category Create(PostCategoryTitle title, PostCategoryName name, PostCategoryDescription description) =>
        new(Guid.NewGuid(), title, name, description);

    public void Update(PostCategoryTitle title, PostCategoryName name, PostCategoryDescription description, bool updateSlug = false)
    {
        Title = title ?? throw new KSArgumentNullException(nameof(title));
        Name = name ?? throw new KSArgumentNullException(nameof(name));
        if (updateSlug) Slug = PostCategorySlug.Create(name.Value);
        Description = description;
    }

    protected Category(Guid id) : base(id) { }

    public PostCategoryTitle Title { get; private set; }
    public PostCategorySlug Slug { get; private set; }
    public PostCategoryName Name { get; private set; }
    public PostCategoryDescription? Description { get; private set; }

    public IReadOnlyCollection<Post> Posts => _posts;
    private List<Post> _posts = new();


    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Id), Id);
        info.AddValue(nameof(Title), Title);
        info.AddValue(nameof(Slug), Slug);
        info.AddValue(nameof(Name), Name);
        info.AddValue(nameof(Description), Description);
        info.AddValue(nameof(Posts), Posts);
    }
}