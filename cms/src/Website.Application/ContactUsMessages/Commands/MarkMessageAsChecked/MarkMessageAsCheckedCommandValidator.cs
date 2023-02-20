namespace Website.Application.ContactUsMessages.Commands.MarkMessageAsChecked;

public class MarkMessageAsCheckedCommandValidator : AbstractValidator<MarkMessageAsCheckedCommand>
{
    public MarkMessageAsCheckedCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}