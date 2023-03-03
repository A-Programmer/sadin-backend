using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostSeoDescription : ValueObject
{
    private const int MaxLength = 250;
    public string Value { get; private set; }

    private PostSeoDescription(string value)
    {
        Value = value;
    }

    public static PostSeoDescription Create(string postSeDescription)
    {
        if (!postSeDescription.HasValue()) throw new KSArgumentNullException($"{nameof(postSeDescription)}");
        if (postSeDescription.Length > MaxLength)
            throw new KSValidationException($"{nameof(postSeDescription)} must be less than {MaxLength} characters.");
        
        return new PostSeoDescription(postSeDescription);
    }
    
    protected PostSeoDescription() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}