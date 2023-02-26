using KSFramework.Primitives;
using KSFramework.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostCategoryName : ValueObject
{
    public string Value { get;  private set;}

    private PostCategoryName(string value)
    {
        Value = value;
    }

    public static PostCategoryName Create(string postCategoryName)
    {
        if (!postCategoryName.HasValue()) throw new KSArgumentNullException($"{nameof(postCategoryName)}");
        
        return new PostCategoryName(postCategoryName);
    }
    
    protected PostCategoryName() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}