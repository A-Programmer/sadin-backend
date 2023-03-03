using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategoryName : ValueObject
{
    public string Value { get;  private set;}

    private CategoryName(string value)
    {
        Value = value;
    }

    public static CategoryName Create(string postCategoryName)
    {
        if (!postCategoryName.HasValue()) throw new KSArgumentNullException($"{nameof(postCategoryName)}");
        
        return new CategoryName(postCategoryName);
    }
    
    protected CategoryName() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}