namespace Website.Application.ContactUsMessages.Queries.GetUncheckedMessagesCount;

public record GetUncheckedMessagesCountQuery(bool CheckStatus) : IQuery<int>;