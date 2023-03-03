using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostImageUrl : ValueObject
{
    public string Value { get; private set; }

    private PostImageUrl(string value)
    {
        Value = value;
    }

    public static PostImageUrl Create(string postImageUrl)
    {
        if (!postImageUrl.HasValue()) throw new KSArgumentNullException($"{nameof(postImageUrl)}");
        
        return new PostImageUrl(postImageUrl);
    }
    
    protected PostImageUrl() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}