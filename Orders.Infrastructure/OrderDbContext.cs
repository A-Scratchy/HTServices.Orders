using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Domain.OrderAggregate;

namespace Orders.Infrastructure
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Orders;Integrated Security=True");
        }
    }
}