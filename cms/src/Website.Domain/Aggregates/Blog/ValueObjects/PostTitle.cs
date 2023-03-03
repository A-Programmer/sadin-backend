using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostTitle : ValueObject
{
    public string Value { get; private set; }

    private PostTitle(string value)
    {
        Value = value;
    }

    public static PostTitle Create(string postTitle)
    {
        if (!postTitle.HasValue()) throw new KSArgumentNullException($"{nameof(postTitle)}");
        
        return new PostTitle(postTitle);
    }
    
    protected PostTitle() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}