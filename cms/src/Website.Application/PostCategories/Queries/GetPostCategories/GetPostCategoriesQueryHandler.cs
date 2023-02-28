namespace Website.Application.PostCategories.Queries.GetPostCategories;

public class GetPostCategoriesQueryHandler : IQueryHandler<GetPostCategoriesQuery, List<GetPostCategoriesDto>>
{
    private readonly IUnitOfWork _uow;

    public GetPostCategoriesQueryHandler(IUnitOfWork uow) => _uow = uow ?? throw new KSArgumentNullException(nameof(uow));

    public async Task<List<GetPostCategoriesDto>> Handle(GetPostCategoriesQuery request, CancellationToken cancellationToken)
    {
        return (await _uow.Posts.GetAllCategoriesAsync()).Select(x => new GetPostCategoriesDto(x)).ToList();
    }
}