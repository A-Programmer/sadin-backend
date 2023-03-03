using Website.Application.Categories.Queries.GetCategoryBySlug;

namespace Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetPostCategoryBySlug;

public class GetCategoryBySlugItemViewModel
{
    public GetCategoryBySlugItemViewModel(GetCategoryBySlugDto category)
    {
        Id = category.Id;
        Title = category.Title;
        Slug = category.Slug;
        Name = category.Name;
        Description = category.Description;
        Posts = category.Posts.Select(x => new GetCategoryBySlugPostItemViewModel(x)).ToList();
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public List<GetCategoryBySlugPostItemViewModel> Posts { get; private set; }
}