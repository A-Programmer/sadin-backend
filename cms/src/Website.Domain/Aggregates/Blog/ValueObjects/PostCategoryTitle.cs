using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

public sealed class PostCategoryTitle : ValueObject
{
    private const int MaxLength = 160;
    public string Value { get; private set; }

    private PostCategoryTitle(string value)
    {
        Value = value;
    }

    public static PostCategoryTitle Create(string postCatgeoryTitle)
    {
        if (!postCatgeoryTitle.HasValue()) throw new KSArgumentNullException($"{nameof(postCatgeoryTitle)}");
        if (postCatgeoryTitle.Length > MaxLength)
            throw new KSValidationException($"{nameof(postCatgeoryTitle)} must be less than {MaxLength} characters.");

        return new PostCategoryTitle(postCatgeoryTitle);
    }
    
    protected PostCategoryTitle() { }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}