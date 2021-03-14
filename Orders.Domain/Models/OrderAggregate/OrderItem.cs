namespace Orders.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string Name { get; set; } 
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}