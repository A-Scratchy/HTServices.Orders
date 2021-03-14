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
        public AddressDto ShippingAddress { get; set; }
        public AddressDto BillingAddress { get; set; }
        public string OrderStatus { get; set; }
        public string Description { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

        public decimal TotalCost => OrderItems.Aggregate(0M, (a, b) => a += b.Cost);

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailVm>();
        }
    }
}