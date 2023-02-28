namespace Website.Application.PostCategories.Queries.GetPostCategoryBySlug;

public record GetPostCategoryBySlugQuery : IQuery<GetPostCategoryBySlugDto>
{
    public GetPostCategoryBySlugQuery(string slug)
    {
        Slug = slug;
    }
    public string Slug { get; private set; }
}