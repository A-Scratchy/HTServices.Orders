using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Application.ViewModels;

namespace Orders.Application.Queries
{
    public class GetOrderDetailQuery : IRequest<OrderDetailVm>
    {
        public GetOrderDetailQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken) =>
            await _context.Orders.Where(o => o.Id == request.Id)
                .ProjectTo<OrderDetailVm>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(cancellationToken);
    }
}