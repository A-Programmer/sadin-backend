using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostSlug : ValueObject
{
    public string Value { get; private set; }

    private PostSlug(string value)
    {
        Value = value.CreateSlug();
    }

    public static PostSlug Create(string postTitle)
    {
        if (!postTitle.HasValue()) throw new KSArgumentNullException($"{nameof(postTitle)}");
        
        return new PostSlug(postTitle);
    }
    
    protected PostSlug() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}