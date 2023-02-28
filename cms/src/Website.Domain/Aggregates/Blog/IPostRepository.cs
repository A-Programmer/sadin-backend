using KSFramework.GenericRepository;

namespace Website.Domain.Aggregates.Blog;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<ICollection<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryBySlugPostsIncludedAsync(string slug);
}