using System.Runtime.Serialization;
using KSFramework.Primitives;
using Website.Domain.Aggregates.Blog;
using Website.Domain.Aggregates.Categories.ValueObjects;

namespace Website.Domain.Aggregates.Categories;

[Serializable]
public sealed class Category : AggregateRootWithSoftDelete, ISerializable
{
    private Category(Guid id, CategoryTitle title, CategoryName name, CategoryDescription description) 
        : base(id)
    {
        Title = title ?? throw new KSArgumentNullException(nameof(title));
        Name = name ?? throw new KSArgumentNullException(nameof(name));
        Slug = CategorySlug.Create(name.Value);
        Description = description;
    }

    public static Category Create(CategoryTitle title, CategoryName name, CategoryDescription description) =>
        new(Guid.NewGuid(), title, name, description);

    public void Update(CategoryTitle title, CategoryName name, CategoryDescription description, bool updateSlug = false)
    {
        Title = title ?? throw new KSArgumentNullException(nameof(title));
        Name = name ?? throw new KSArgumentNullException(nameof(name));
        if (updateSlug) Slug = CategorySlug.Create(name.Value);
        Description = description;
    }

    protected Category(Guid id) : base(id) { }

    public CategoryTitle Title { get; private set; }
    public CategorySlug Slug { get; private set; }
    public CategoryName Name { get; private set; }
    public CategoryDescription? Description { get; private set; }

    public IReadOnlyCollection<Post> Posts => _posts;
    private List<Post> _posts = new();

    public int PostsCounts() => _posts.Count;


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