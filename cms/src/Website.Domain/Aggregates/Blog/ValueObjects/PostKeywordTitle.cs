using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostKeywordTitle : ValueObject
{
    public string Value { get; private set; }

    private PostKeywordTitle(string value)
    {
        Value = value;
    }

    public static PostKeywordTitle Create(string postKeywordTitle)
    {
        if (!postKeywordTitle.HasValue()) throw new KSArgumentNullException($"{nameof(postKeywordTitle)}");
        
        return new PostKeywordTitle(postKeywordTitle);
    }
    
    protected PostKeywordTitle() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}