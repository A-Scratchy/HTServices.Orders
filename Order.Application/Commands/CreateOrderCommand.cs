﻿using System;
using System.Collections.Generic;
using System.Net.Mail;
using MediatR;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public Guid? OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone { get; set; }
        public DateTime Timestamp { get; set; }
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal ExpectedCost { get; set; }

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
        public string Reference { get; set; }

        public class OrderItem
        {
            public Guid ProductId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}