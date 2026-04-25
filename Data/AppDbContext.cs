using Microsoft.EntityFrameworkCore;

namespace PaymentPortal.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PaymentPortal.Models.Payment> Payments { get; set; }
    }
}
