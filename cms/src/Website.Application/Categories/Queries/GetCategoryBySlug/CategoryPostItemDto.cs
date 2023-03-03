using Website.Domain.Aggregates.Blog;

namespace Website.Application.Categories.Queries.GetCategoryBySlug;

public class CategoryPostItemDto
{
    public CategoryPostItemDto(Post post)
    {
        Id = post.Id;
        Title = post.Title.Value;
        Slug = post.Slug.Value;
        Description = post.Description.Value;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
}