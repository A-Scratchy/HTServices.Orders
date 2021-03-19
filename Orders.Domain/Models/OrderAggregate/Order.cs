using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime OrderDate { get; set; }
        public string Reference { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Description { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        
        public decimal TotalCost => OrderItems.Aggregate(0M, (a, b) => a += b.Price);

        public Order()
        {
        }

    }
}