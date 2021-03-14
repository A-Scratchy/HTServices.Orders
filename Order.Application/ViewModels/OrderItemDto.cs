using AutoMapper;
using Orders.Application.Interfaces;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.ViewModels
{
    public class OrderItemDto : IMapFrom<OrderItem>
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<OrderItem, OrderItemDto>();
    }
}