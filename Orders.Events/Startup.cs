using System.Reflection;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Commands;
using Orders.Application.Commands.Handlers;
using Orders.Application.Interfaces;
using Orders.Infrastructure;

[assembly: FunctionsStartup(typeof(Orders.Events.Startup))]

namespace Orders.Events
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IOrderDbContext, OrderDbContext>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(typeof(CreateOrderCommandHandler));
        }
    }
}