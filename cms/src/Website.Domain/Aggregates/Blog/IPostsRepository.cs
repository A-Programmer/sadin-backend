using KSFramework.GenericRepository;

namespace Website.Domain.Aggregates.Blog;

public interface IPostsRepository : IGenericRepository<Post>
{
}