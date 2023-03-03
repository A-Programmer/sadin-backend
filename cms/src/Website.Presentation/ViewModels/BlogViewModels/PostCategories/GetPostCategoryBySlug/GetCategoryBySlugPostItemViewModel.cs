using Website.Application.Categories.Queries.GetCategoryBySlug;

namespace Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetPostCategoryBySlug;

public class GetCategoryBySlugPostItemViewModel
{
    public GetCategoryBySlugPostItemViewModel(CategoryPostItemDto categoryPost)
    {
        Id = categoryPost.Id;
        Title = categoryPost.Title;
        Slug = categoryPost.Slug;
        Description = categoryPost.Description;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
}