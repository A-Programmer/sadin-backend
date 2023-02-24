namespace Website.Application.ContactUsMessages.Queries.GetUncheckedMessagesCount;

public sealed record GetUncheckedMessagesCountQuery(bool CheckStatus) : IQuery<int>;