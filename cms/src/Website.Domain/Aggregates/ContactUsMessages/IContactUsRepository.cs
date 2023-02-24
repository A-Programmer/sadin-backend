using System.Linq.Expressions;
using KSFramework.GenericRepository;
using KSFramework.Pagination;

namespace Website.Domain.Aggregates.ContactUsMessages;

public interface IContactUsRepository : IGenericRepository<ContactUsMessage>
{
    Task<PaginatedList<ContactUsMessage>> GetUncheckedPagedMessagesAsync(int pageIndex, int pageSize, Expression<Func<ContactUsMessage, bool>> where = null, string orderBy = "", bool desc = false);
    Task<int> GetMessagesCountByCheckStatusAsync(bool checkStatus);
}