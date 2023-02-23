namespace Website.Application.ContactUsMessages.Commands.RemoveMessage;

public sealed record RemoveMessageCommand(Guid Id) : ICommand<BaseResponse<Guid>>;