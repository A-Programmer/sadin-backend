using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostCategoryDescription : ValueObject
{
    public string Value { get; private set; }

    private PostCategoryDescription(string value)
    {
        Value = value;
    }

    public static PostCategoryDescription Create(string postCategoryDescription)
    {
        if (!postCategoryDescription.HasValue()) throw new KSArgumentNullException($"{nameof(postCategoryDescription)}");
        
        return new PostCategoryDescription(postCategoryDescription);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    protected PostCategoryDescription() { }

    public override string ToString()
    {
        return $"{Value}";
    }
}