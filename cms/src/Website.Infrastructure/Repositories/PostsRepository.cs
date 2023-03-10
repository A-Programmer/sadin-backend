using Microsoft.EntityFrameworkCore;
using Website.Domain.Aggregates.Blog;
using Website.Infrastructure.Data;

namespace Website.Infrastructure.Repositories;

public class PostsRepository : GenericRepository<Post>, IPostsRepository
{
    public PostsRepository(DbContext context) : base(context)
    {
    }
    
    
    public WebsiteDbContext DbContext
    {
        get
        {
            return DbContext as WebsiteDbContext;
        }
    }
}