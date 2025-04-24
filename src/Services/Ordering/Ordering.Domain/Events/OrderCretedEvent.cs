namespace Ordering.Domain.Events
{
    public record OrderCretedEvent(Order order) : IDomainEvent
    {
    }
}
