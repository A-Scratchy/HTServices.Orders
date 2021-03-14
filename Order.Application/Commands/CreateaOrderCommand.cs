using System.Collections.Generic;
using MediatR;

namespace Orders.Application.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public string Reference { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPostCode { get; set; }
        public string BillingStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostCode { get; set; }
        public string Description { get; set; }
        public List<CreateOrderCommandOrderItem> OrderItems { get; set; }

        public class CreateOrderCommandOrderItem
        {
            public string Name { get; set; }
            public decimal Cost { get; set; }
            public int Quantity { get; set; }
        }
    }
}