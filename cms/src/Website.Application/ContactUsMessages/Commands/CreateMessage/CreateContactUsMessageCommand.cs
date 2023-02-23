namespace Website.Application.ContactUsMessages.Commands.CreateMessage;

public sealed record CreateContactUsMessageCommand(string Title, string Content, string FullName = null, string Email = null,
    string PhoneNumber = null) : ICommand<BaseResponse<Guid>>;