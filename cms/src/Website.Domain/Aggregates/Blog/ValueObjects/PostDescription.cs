using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostDescription : ValueObject
{
    public string Value { get; private set; }

    private PostDescription(string value)
    {
        Value = value;
    }

    public static PostDescription Create(string postDescription)
    {
        if (!postDescription.HasValue()) throw new KSArgumentNullException($"{nameof(postDescription)}");
        
        return new PostDescription(postDescription);
    }
    
    protected PostDescription() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}