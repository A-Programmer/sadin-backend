namespace Website.Application.ContactUsMessages.Commands.RemoveMessage;

internal sealed class RemoveMessageCommandHandler : ICommandHandler<RemoveMessageCommand, BaseResponse<Guid>>
{
    private readonly IUnitOfWork _uow;
    public RemoveMessageCommandHandler(IUnitOfWork uow) => _uow = uow ?? throw new ArgumentNullException(nameof(uow));

    public async Task<BaseResponse<Guid>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _uow.ContactUsMessages.GetByIdAsync(request.Id);
        if(message == null)
            throw new KSNotFoundException("Message could not be found.");
        _uow.ContactUsMessages.Remove(message);
        await _uow.CommitAsync();
        return new OkResponse<Guid>(request.Id);
    }
}
