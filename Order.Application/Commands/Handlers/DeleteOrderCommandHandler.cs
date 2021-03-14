using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orders.Application.Interfaces;

namespace Orders.Application.Commands.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderDbContext _context;

        public DeleteOrderCommandHandler(IOrderDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FindAsync(request.Id);
            
            _context.Orders.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}