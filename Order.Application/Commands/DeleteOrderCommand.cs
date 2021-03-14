using System;
using MediatR;

namespace Orders.Application.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}