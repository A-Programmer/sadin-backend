using Website.Application.PostCategories.Queries.GetPostCategoryBySlug;

namespace Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetPostCategoryBySlug;

public class GetPostCategoryBySlugPostItemViewModel
{
    public GetPostCategoryBySlugPostItemViewModel(PostCategoryPostItemDto post)
    {
        Id = post.Id;
        Title = post.Title;
        Slug = post.Slug;
        Description = post.Description;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
}