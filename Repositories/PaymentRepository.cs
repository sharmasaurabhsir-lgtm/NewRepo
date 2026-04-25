using Microsoft.EntityFrameworkCore;
using PaymentPortal.Data;
using PaymentPortal.Models;

namespace PaymentPortal.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> GetByClientRequestId(string clientRequestId)
            => await _context.Payments.FirstOrDefaultAsync(x => x.ClientRequestId == clientRequestId);

        public async Task<List<Payment>> GetAll()
            => await _context.Payments.OrderByDescending(x => x.CreatedAt).ToListAsync();

        public async Task<Payment> GetById(Guid id)
            => await _context.Payments.FindAsync(id);

        public async Task Add(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Payment payment)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTodayCount(DateTime date)
            => await _context.Payments.CountAsync(x => x.CreatedAt.Date == date.Date);
    }
}
