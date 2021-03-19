using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}