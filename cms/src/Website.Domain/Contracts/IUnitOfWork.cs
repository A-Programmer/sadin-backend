using Website.Domain.Aggregates.Blog;
using Website.Domain.Aggregates.Categories;
using Website.Domain.Aggregates.ContactUsMessages;

namespace Website.Domain.Contracts;

public interface IUnitOfWork : IDisposable
{
    public  IContactUsRepository ContactUsMessages { get; }
    public IPostsRepository Posts { get; }
    public ICategoriesRepository Categories { get; }
    
    Task<int> CommitAsync();
}