using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orders.Application.Interfaces;

namespace Orders.Application.Commands.Handlers
{
    public class ReplaceOrderCommandHandler : IRequestHandler<ReplaceOrderCommand>
    {
        private readonly IOrderDbContext _context;

        public ReplaceOrderCommandHandler(IOrderDbContext context) => _context = context;

        public async Task<Unit> Handle(ReplaceOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FindAsync(request.Id);

            if (request.Reference != null)
                entity.Reference = request.Reference;
            
            _context.Orders.Update(entity);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}