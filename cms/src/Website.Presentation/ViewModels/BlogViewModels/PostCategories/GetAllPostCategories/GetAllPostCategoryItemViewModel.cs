using Website.Application.PostCategories.Queries.GetPostCategories;

namespace Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetAllPostCategories;

public class GetAllPostCategoryItemViewModel
{
    public GetAllPostCategoryItemViewModel(GetPostCategoriesDto categoryPost)
    {
        Id = categoryPost.Id;
        Title = categoryPost.Title;
        Slug = categoryPost.Slug;
        Description = categoryPost.Description;
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string? Description { get; private set; }
}
