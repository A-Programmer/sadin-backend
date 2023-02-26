using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostCommentContent : ValueObject
{
    public string Value { get; private set; }

    private PostCommentContent(string value)
    {
        Value = value;
    }

    public static PostCommentContent Create(string postCommentContent)
    {
        if (!postCommentContent.HasValue()) throw new KSArgumentNullException($"{nameof(postCommentContent)}");
        
        return new PostCommentContent(postCommentContent);
    }
    
    private PostCommentContent() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}