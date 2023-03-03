using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategoryDescription : ValueObject
{
    public string Value { get; private set; }

    private CategoryDescription(string value)
    {
        Value = value;
    }

    public static CategoryDescription Create(string postCategoryDescription)
    {
        if (!postCategoryDescription.HasValue()) throw new KSArgumentNullException($"{nameof(postCategoryDescription)}");
        
        return new CategoryDescription(postCategoryDescription);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    protected CategoryDescription() { }

    public override string ToString()
    {
        return $"{Value}";
    }
}