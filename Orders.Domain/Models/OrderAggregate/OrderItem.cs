using System;

namespace Orders.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}