namespace Website.Application.ContactUsMessages.Commands.MarkMessageAsUnchecked;

public record MarkMessageAsUncheckedCommand(Guid Id) : ICommand<BaseResponse<Guid>>;