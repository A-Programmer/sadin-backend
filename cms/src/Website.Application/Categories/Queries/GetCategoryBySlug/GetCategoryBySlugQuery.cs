namespace Website.Application.Categories.Queries.GetCategoryBySlug;

public record GetCategoryBySlugQuery : IQuery<GetCategoryBySlugDto>
{
    public GetCategoryBySlugQuery(string slug)
    {
        Slug = slug;
    }
    public string Slug { get; private set; }
}