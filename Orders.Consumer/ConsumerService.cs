using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Orders.Consumer.Events;

namespace Orders.Consumer
{
    public class ConsumerService  : BackgroundService
    {
        private readonly ISubscriptionClient _subscriptionClient;

        public ConsumerService(ISubscriptionClient subscriptionClient)
        {
            _subscriptionClient = subscriptionClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriptionClient.RegisterMessageHandler((message, token) =>
            {
                var orderPlacedEvent =
                    JsonConvert.DeserializeObject<OrderPlacedEvent>(Encoding.UTF8.GetString(message.Body));
                
                Console.WriteLine($"Order received! {Encoding.UTF8.GetString(message.Body)}");

                return Task.CompletedTask;
            }, args =>
            {
               Console.WriteLine($"error with message{args.Exception}"); 
                return Task.CompletedTask;
            });
            
            
            return Task.CompletedTask;
        }
    }
}