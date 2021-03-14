using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Orders.Application.Interfaces;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.ViewModels
{
    public class OrderDetailVm : IMapFrom<Order>
    {
        public string Reference { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Description { get; set; }
        public List<CreateOrderItem> OrderItems { get; set; }

        public decimal TotalCost => OrderItems.Aggregate(0M, (a, b) => a += b.Cost);

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailVm>()
                .ForMember(o => o.OrderItems, opt => opt.MapFrom(o => o.OrderItems));
        }
    }
}