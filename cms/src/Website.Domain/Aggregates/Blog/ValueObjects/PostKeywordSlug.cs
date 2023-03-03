using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostKeywordSlug : ValueObject
{
    public string Value { get; private set; }

    private PostKeywordSlug(string value)
    {
        Value = value.CreateSlug();
    }

    public static PostKeywordSlug Create(string postKeywordName)
    {
        if (!postKeywordName.HasValue()) throw new KSArgumentNullException($"{nameof(postKeywordName)}");
        
        return new PostKeywordSlug(postKeywordName);
    }
    
    protected PostKeywordSlug() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}