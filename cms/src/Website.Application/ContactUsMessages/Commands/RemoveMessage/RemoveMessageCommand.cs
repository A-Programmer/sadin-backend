namespace Website.Application.ContactUsMessages.Commands.RemoveMessage;

public record RemoveMessageCommand(Guid Id) : ICommand<BaseResponse<Guid>>;