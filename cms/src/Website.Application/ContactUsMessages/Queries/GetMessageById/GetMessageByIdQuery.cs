namespace Website.Application.ContactUsMessages.Queries.GetMessageById;

public record GetMessageByIdQuery(Guid Id) : IQuery<GetMessageByIdDto>;