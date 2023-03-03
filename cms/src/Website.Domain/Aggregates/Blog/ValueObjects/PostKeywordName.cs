using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostKeywordName : ValueObject
{
    public string Value { get; private set; }

    private PostKeywordName(string value)
    {
        Value = value;
    }

    public static PostKeywordName Create(string postKeywordName)
    {
        if (!postKeywordName.HasValue()) throw new KSArgumentNullException($"{nameof(postKeywordName)}");
        
        return new PostKeywordName(postKeywordName);
    }
    
    protected PostKeywordName() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}