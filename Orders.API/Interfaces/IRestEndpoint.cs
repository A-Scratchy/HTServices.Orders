using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Orders.API.Interfaces
{
    public interface IRestEndpoint<TOne, TMany>
    {
        public Task<TOne> Get(Guid id);
        public Task<ActionResult<TMany>> Get();
        public Task<ActionResult> Create(IRequest command);
        public Task<ActionResult> Replace(IRequest command);
        public Task<ActionResult> Update(IRequest command);
        public Task<ActionResult> Delete(IRequest command);
    }
}