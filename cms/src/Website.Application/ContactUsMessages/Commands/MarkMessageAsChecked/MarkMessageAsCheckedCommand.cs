namespace Website.Application.ContactUsMessages.Commands.MarkMessageAsChecked;

public sealed record MarkMessageAsCheckedCommand(Guid Id) : ICommand<BaseResponse<Guid>>;