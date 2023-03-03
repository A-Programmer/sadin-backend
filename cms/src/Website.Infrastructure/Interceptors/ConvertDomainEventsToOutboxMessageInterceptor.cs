using KSFramework.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Website.Domain.Aggregates.EventMessages;

namespace Website.Infrastructure.Interceptors;

public sealed class ConvertDomainEventsToOutboxMessageInterceptor
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        DbContext? dbContext = eventData.Context;
        if (dbContext is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var outboxMessages = dbContext.ChangeTracker
            .Entries<AggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var domainEvents = aggregateRoot.DomainEvents.ToList();
                aggregateRoot.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(Guid.NewGuid(),
                domainEvent.GetType().Name, 
                JsonConvert.SerializeObject(
                domainEvent,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }) ,DateTimeOffset.UtcNow, null, null)
            )
            .ToList();
        
        dbContext.Set<OutboxMessage>().AddRange(outboxMessages);
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}