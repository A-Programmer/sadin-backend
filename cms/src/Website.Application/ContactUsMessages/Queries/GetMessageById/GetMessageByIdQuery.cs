namespace Website.Application.ContactUsMessages.Queries.GetMessageById;

public sealed record GetMessageByIdQuery(Guid Id) : IQuery<GetMessageByIdDto>;