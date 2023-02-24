namespace Website.Application.ContactUsMessages.Commands.MarkMessageAsUnchecked;

public sealed record MarkMessageAsUncheckedCommand(Guid Id) : ICommand<BaseResponse<Guid>>;