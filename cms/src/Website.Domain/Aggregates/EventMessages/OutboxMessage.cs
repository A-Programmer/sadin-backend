using KSFramework.Primitives;

namespace Website.Domain.Aggregates.EventMessages;

public sealed class OutboxMessage : EntityWithSoftDelete
{
    public string Type { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public DateTimeOffset OccuredUtc { get; private set; }
    public DateTimeOffset? ProcessedUtc { get; private set; }
    public string? Error { get; private set; }

    public OutboxMessage(Guid id, string type, string content,
        DateTimeOffset occuredUtc, DateTimeOffset? processedUtc,
        string? error) : base(id)
    {
        Type = type;
        Content = content;
        OccuredUtc = occuredUtc;
        ProcessedUtc = processedUtc;
        Error = error;
    }
    
    protected OutboxMessage(Guid id) : base(id)
    { }
}