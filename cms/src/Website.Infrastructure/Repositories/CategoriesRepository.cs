using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Website.Domain.Aggregates.Categories;
using Website.Infrastructure.Data;

namespace Website.Infrastructure.Repositories;

public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
{
    public CategoriesRepository(DbContext context) : base(context)
    {
    }
    
    public async Task<Category> GetCategoryBySlugPostsIncludedAsync(string slug)
    {
        return await Entity.Include(c => c.Posts.Where(p => p.IsPublished)).AsNoTracking()
            .FirstOrDefaultAsync(ct => ct.Slug.Value.ToLower() == slug.ToLower());
            
    }
    
    public WebsiteDbContext DbContext
    {
        get
        {
            return DbContext as WebsiteDbContext;
        }
    }
}