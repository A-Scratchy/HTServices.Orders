using System.Threading.Tasks;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using OrderPipelineContracts;
using Orders.Application.Commands;
using Orders.Domain.OrderAggregate;
using Orders.Events.Events;

namespace Orders.Events
{
    public class OrderEventProcessor
    {
        private const string InQueue = "orderplacedpendingapproval";
        private const string OutQueue = "ordercreated";
        private readonly ISender _mediator;

        public OrderEventProcessor(ISender mediator) => _mediator = mediator;


        [FunctionName("SaveNewOrder")]
        [return: ServiceBus(OutQueue, Connection = "ServiceBusConnection")]
        public async Task<OrderCreatedEvent> RunAsync([ServiceBusTrigger(InQueue, Connection = "ServiceBusConnection")]
                                                      OrderPlacedPendingApproval order, ILogger log)
        {
            log.LogInformation(
                $"C# ServiceBus queue trigger function processed message from orders enriched: {order.FirstName} {order.LastName}");

            var command = new CreateOrderCommand
            {
                Status = OrderStatus.New,
                ShippingStreet = order.ShippingStreet,
                ShippingCity = order.ShippingCity,
                ShippingState = order.ShippingState,
                ShippingCountry = order.ShippingCountry,
                ShippingPostCode = order.ShippingPostCode,

                BillingStreet = order.BillingStreet,
                BillingCity = order.BillingCity,
                BillingState = order.BillingState,
                BillingCountry = order.BillingCountry,
                BillingPostCode = order.BillingPostCode,

                ExpectedCost = order.ExpectedCost,
                FirstName = order.FirstName,
                LastName = order.LastName,
                ContactEmail = order.ContactEmail,
                ContactTelephone = order.ContactTelephone,
                Timestamp = order.Timestamp,
                Description =
                    $"{order.FirstName} {order.LastName} : {order.Timestamp.ToShortDateString()} {order.Timestamp.ToShortTimeString()}"
            };

            foreach (var item in order.OrderItems)
                command.OrderItems.Add(new CreateOrderCommand.OrderItem
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Quantity = item.Quantity
                });

            await _mediator.Send(command);

            return new OrderCreatedEvent(order.OrderId);
        }
    }
}