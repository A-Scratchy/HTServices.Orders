using System;
using System.Threading.Tasks;

namespace Orders.Domain.OrderAggregate
{
    public interface IOrderRepository
    {
        Order Add(Order order);

        Task<Order> GetAsync(Guid id);
    }
}