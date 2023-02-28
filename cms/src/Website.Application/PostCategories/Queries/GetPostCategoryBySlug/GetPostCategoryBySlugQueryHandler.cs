namespace Website.Application.PostCategories.Queries.GetPostCategoryBySlug;

public sealed class GetPostCategoryBySlugQueryHandler : IQueryHandler<GetPostCategoryBySlugQuery, GetPostCategoryBySlugDto>
{
    private readonly IUnitOfWork _uow;

    public GetPostCategoryBySlugQueryHandler(IUnitOfWork uow) => _uow = uow ?? throw new KSArgumentNullException(nameof(uow));

    public async Task<GetPostCategoryBySlugDto> Handle(GetPostCategoryBySlugQuery request, CancellationToken cancellationToken)
    {
        return new GetPostCategoryBySlugDto(await _uow.Posts.GetCategoryBySlugPostsIncludedAsync(request.Slug));
    }
}