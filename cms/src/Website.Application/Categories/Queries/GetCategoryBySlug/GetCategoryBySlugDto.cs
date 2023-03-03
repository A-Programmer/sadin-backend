using Website.Domain.Aggregates.Blog;
using Website.Domain.Aggregates.Categories;

namespace Website.Application.Categories.Queries.GetCategoryBySlug;

public class GetCategoryBySlugDto
{
    public GetCategoryBySlugDto(Category category)
    {
        Id = category.Id;
        Title = category.Title.Value;
        Slug = category.Slug.Value;
        Name = category.Name.Value;
        Description = category.Description?.Value;
        Posts = category.Posts
            .Select(x => new CategoryPostItemDto(x)).ToList();
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public List<CategoryPostItemDto> Posts { get; private set; }
}