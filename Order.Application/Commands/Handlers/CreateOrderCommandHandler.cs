using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orders.Application.Interfaces;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderDbContext _context;

        public CreateOrderCommandHandler(IOrderDbContext context) => _context = context;

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order()
            {
                Id = request.OrderId ?? new Guid(),
                Reference = request.Reference,
                BillingAddress = new Address(request.BillingStreet, request.BillingCity, request.BillingState,
                    request.BillingCountry, request.BillingPostCode),
                ShippingAddress = new Address(request.ShippingStreet, request.ShippingCity, request.ShippingState,
                    request.ShippingCountry, request.ShippingPostCode),
                OrderStatus = OrderStatus.New,
                Description = request.Description,
            };
            foreach (var item in request.OrderItems)
            {
                entity.OrderItems.Add(new OrderItem()
                {
                    ProductName = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            await _context.Orders.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}