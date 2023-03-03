using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostSeoTitle : ValueObject
{
    private const int MaxLength = 160;
    public string Value { get; private set; }

    private PostSeoTitle(string value)
    {
        Value = value;
    }

    public static PostSeoTitle Create(string postSeoTitle)
    {
        if (!postSeoTitle.HasValue()) throw new KSArgumentNullException($"{nameof(postSeoTitle)}");
        if (postSeoTitle.Length > MaxLength)
            throw new KSValidationException($"{nameof(postSeoTitle)} must be less than {MaxLength} characters.");
        
        return new PostSeoTitle(postSeoTitle);
    }
    
    protected PostSeoTitle() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}