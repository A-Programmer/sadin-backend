using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategorySlug : ValueObject
{
    public string Value { get; private set; }

    private CategorySlug(string value)
    {
        Value = value.CreateSlug();
    }

    public static CategorySlug Create(string postCategoryName)
    {
        if (!postCategoryName.HasValue()) throw new KSArgumentNullException($"{nameof(postCategoryName)}");
        
        return new CategorySlug(postCategoryName);
    }
    
    protected CategorySlug() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}