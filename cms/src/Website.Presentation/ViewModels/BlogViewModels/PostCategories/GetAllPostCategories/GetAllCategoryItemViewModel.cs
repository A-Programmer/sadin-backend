using Website.Application.Categories.Queries.GetCategories;

namespace Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetAllPostCategories;

public class GetAllCategoryItemViewModel
{
    public GetAllCategoryItemViewModel(GetCategoriesDto category)
    {
        Id = category.Id;
        Title = category.Title;
        Slug = category.Slug;
        Description = category.Description;
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string? Description { get; private set; }
}
