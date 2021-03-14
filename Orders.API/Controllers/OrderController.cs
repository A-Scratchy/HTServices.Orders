using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands;
using Orders.Application.Queries;
using Orders.Application.ViewModels;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ISender _mediator;

        public OrderController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<OrderListVm>> Get() =>
            await _mediator.Send(new GetOrderListQuery());

        [HttpGet("{id}")]
        public async Task<OrderDetailVm> Get(Guid id) => await _mediator.Send(new GetOrderDetailQuery(id));

        [HttpPost]       
        public async Task<ActionResult> Create(CreateOrderCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public Task<ActionResult> Replace(ReplaceOrderCommand command) => throw new NotImplementedException();

        [HttpPatch("{id}")]
        public Task<ActionResult> Update(UpdateOrderCommand command) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public Task<ActionResult> Delete(DeleteOrderCommand command) => throw new NotImplementedException();
    }

}