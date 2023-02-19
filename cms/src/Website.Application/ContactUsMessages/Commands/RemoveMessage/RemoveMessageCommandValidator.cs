namespace Website.Application.ContactUsMessages.Commands.RemoveMessage;

public class RemoveMessageCommandValidator : AbstractValidator<RemoveMessageCommand>
{
    public RemoveMessageCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}