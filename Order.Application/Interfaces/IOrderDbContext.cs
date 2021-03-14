using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Orders.Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Orders.Domain.OrderAggregate.Order> Orders { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}