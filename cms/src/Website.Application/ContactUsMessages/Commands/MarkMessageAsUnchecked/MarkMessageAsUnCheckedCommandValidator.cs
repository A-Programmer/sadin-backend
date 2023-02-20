namespace Website.Application.ContactUsMessages.Commands.MarkMessageAsUnchecked;

public class MarkMessageAsUnCheckedCommandValidator : AbstractValidator<MarkMessageAsUncheckedCommand>
{
    public MarkMessageAsUnCheckedCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}