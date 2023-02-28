using Website.Domain.Aggregates.Blog;

namespace Website.Application.PostCategories.Queries.GetPostCategoryBySlug;

public class GetPostCategoryBySlugDto
{
    public GetPostCategoryBySlugDto(Category category)
    {
        Id = category.Id;
        Title = category.Title.Value;
        Slug = category.Slug.Value;
        Name = category.Name.Value;
        Description = category.Description?.Value;
        Posts = category.Posts
            .Select(x => new PostCategoryPostItemDto(x)).ToList();
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public List<PostCategoryPostItemDto> Posts { get; private set; }
}