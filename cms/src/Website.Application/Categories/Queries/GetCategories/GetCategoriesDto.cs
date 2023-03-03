using Website.Domain.Aggregates.Categories;

namespace Website.Application.Categories.Queries.GetCategories;

public class GetCategoriesDto
{
    public GetCategoriesDto(Category? category)
    {
        if (category is null) return;
        
        Id = category.Id;
        Title = category.Title.Value;
        Slug = category.Slug.Value;
        Name = category.Name.Value;
        Description = category.Description?.Value;
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
}