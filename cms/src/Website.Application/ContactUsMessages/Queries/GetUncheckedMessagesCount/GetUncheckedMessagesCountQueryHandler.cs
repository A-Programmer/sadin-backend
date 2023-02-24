namespace Website.Application.ContactUsMessages.Queries.GetUncheckedMessagesCount;

internal sealed  class GetUncheckedMessagesCountQueryHandler : IQueryHandler<GetUncheckedMessagesCountQuery, int>
{
    private readonly IUnitOfWork _uow;
    public GetUncheckedMessagesCountQueryHandler(IUnitOfWork uow) => _uow = uow ?? throw new ArgumentNullException(nameof(uow));

    public async Task<int> Handle(GetUncheckedMessagesCountQuery request, CancellationToken cancellationToken)
    {
        return await _uow.ContactUsMessages.GetMessagesCountByCheckStatusAsync(request.CheckStatus);
    }
}
