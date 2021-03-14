using System;
using MediatR;

namespace Orders.Application.Commands
{
    public class ReplaceOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string Reference { get; set; }
    }
}