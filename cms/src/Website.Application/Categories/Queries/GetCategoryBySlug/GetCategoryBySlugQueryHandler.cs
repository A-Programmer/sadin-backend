using Website.Domain.Contracts;

namespace Website.Application.Categories.Queries.GetCategoryBySlug;

public sealed class GetCategoryBySlugQueryHandler : IQueryHandler<GetCategoryBySlugQuery, GetCategoryBySlugDto>
{
    private readonly IUnitOfWork _uow;

    public GetCategoryBySlugQueryHandler(IUnitOfWork uow) => _uow = uow ?? throw new KSArgumentNullException(nameof(uow));

    public async Task<GetCategoryBySlugDto> Handle(GetCategoryBySlugQuery request, CancellationToken cancellationToken)
    {
        return new GetCategoryBySlugDto(await _uow.Categories.GetCategoryBySlugPostsIncludedAsync(request.Slug));
    }
}