using Website.Domain.Aggregates.Blog;
using Website.Domain.Aggregates.ContactUsMessages;

namespace Website.Domain;

public interface IUnitOfWork : IDisposable
{
    public  IContactUsRepository ContactUsMessages { get; }
    public IPostRepository Posts { get; }
    
    Task<int> CommitAsync();
}