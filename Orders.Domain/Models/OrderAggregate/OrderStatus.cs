namespace Orders.Domain.OrderAggregate
{
    public enum OrderStatus
    {
       New,
       AwaitingValidation,
       Confirmed,
       Paid,
       Shipped,
       Cancelled,
       Complete
    }
}