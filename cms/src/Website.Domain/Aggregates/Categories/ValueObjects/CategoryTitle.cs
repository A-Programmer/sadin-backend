using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategoryTitle : ValueObject
{
    private const int MaxLength = 160;
    public string Value { get; private set; }

    private CategoryTitle(string value)
    {
        Value = value;
    }

    public static CategoryTitle Create(string postCatgeoryTitle)
    {
        if (!postCatgeoryTitle.HasValue()) throw new KSArgumentNullException($"{nameof(postCatgeoryTitle)}");
        if (postCatgeoryTitle.Length > MaxLength)
            throw new KSValidationException($"{nameof(postCatgeoryTitle)} must be less than {MaxLength} characters.");

        return new CategoryTitle(postCatgeoryTitle);
    }
    
    protected CategoryTitle() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}