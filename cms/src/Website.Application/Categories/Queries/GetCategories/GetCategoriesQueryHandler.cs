using Website.Domain.Aggregates.Categories;
using Website.Domain.Contracts;

namespace Website.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<GetCategoriesDto>>
{
    private readonly IUnitOfWork _uow;

    public GetCategoriesQueryHandler(IUnitOfWork uow) => _uow = uow ?? throw new KSArgumentNullException(nameof(uow));

    public async Task<List<GetCategoriesDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return (await _uow.Categories.GetAllAsync())
            .Select(x => new GetCategoriesDto(x))
            .ToList();
    }
}