using Microsoft.EntityFrameworkCore;
using Website.Domain.Aggregates.Blog;
using Website.Infrastructure.Data;

namespace Website.Infrastructure.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DbContext context) : base(context)
    {
    }
    
    public async Task<ICollection<Category>> GetAllCategoriesAsync()
    {
        return await Entity.Include(x => x.Categories)
            .SelectMany(x => x.Categories).Distinct().ToListAsync();
    }

    public async Task<Category> GetCategoryBySlugPostsIncludedAsync(string slug)
    {
        return await Entity.Include(x => x.Categories)
            .SelectMany(x => x.Categories)
            .Include(x => x.Posts)
            .FirstOrDefaultAsync(x => string.Equals(x.Slug.Value, slug, StringComparison.OrdinalIgnoreCase));
            
    }
    
    public WebsiteDbContext DbContext
    {
        get
        {
            return DbContext as WebsiteDbContext;
        }
    }
}