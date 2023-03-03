using KSFramework.Primitives;
namespace Website.Application.Common.Events;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent

{

}
