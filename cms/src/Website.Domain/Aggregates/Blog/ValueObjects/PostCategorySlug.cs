using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostCategorySlug : ValueObject
{
    public string Value { get; private set; }

    private PostCategorySlug(string value)
    {
        Value = value.CreateSlug();
    }

    public static PostCategorySlug Create(string postCategoryName)
    {
        if (!postCategoryName.HasValue()) throw new KSArgumentNullException($"{nameof(postCategoryName)}");
        
        return new PostCategorySlug(postCategoryName);
    }
    
    protected PostCategorySlug() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}