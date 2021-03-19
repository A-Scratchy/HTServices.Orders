using System;

namespace Orders.Events.Events
{
    public class OrderCreatedEvent
    {
        public Guid OrderOrderId { get; }

        public OrderCreatedEvent(Guid orderOrderId)
        {
            OrderOrderId = orderOrderId;
        }
    }
}