using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Models
{
    public class BookingDbContext : DbContext
    {
        private static DbContextOptions options;


        public DbSet<Customer> Customers { get; set; }
    }
}
