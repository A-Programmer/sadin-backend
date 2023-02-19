namespace Website.Application.ContactUsMessages.Commands.CreateMessage;

public class CreateContactUsMessageCommandValidator : AbstractValidator<CreateContactUsMessageCommand>
{
    public CreateContactUsMessageCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
    }
}