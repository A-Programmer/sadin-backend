using KSFramework.GenericRepository;

namespace Website.Domain.Aggregates.Categories;

public interface ICategoriesRepository : IGenericRepository<Category>
{
    Task<Category> GetCategoryBySlugPostsIncludedAsync(string slug);
}