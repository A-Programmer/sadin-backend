using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostContent : ValueObject
{
    public string Value { get; private set; }

    private PostContent(string value)
    {
        Value = value;
    }

    public static PostContent Create(string postContent)
    {
        if (!postContent.HasValue()) throw new KSArgumentNullException($"{nameof(postContent)}");
        
        return new PostContent(postContent);
    }
    
    protected PostContent() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}