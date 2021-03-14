using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.Queries
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
    }

    public class OrderListVm : IRecordList<OrderRecordDto>
    {
        public ICollection<OrderRecordDto> Records { get; set; }
        public int Results => Records.Count;
    }


    public class OrderRecordDto : IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        private string Description { get; set; }
        public string OrderStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderRecordDto>();
        }
    }

    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IMapper mapper, IOrderDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return new OrderListVm()
            {
                Records = await _context.Orders.AsNoTracking().ProjectTo<OrderRecordDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}