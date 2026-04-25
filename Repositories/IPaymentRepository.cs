using PaymentPortal.Models;

namespace PaymentPortal.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByClientRequestId(string clientRequestId);
        Task<List<Payment>> GetAll();
        Task<Payment> GetById(Guid id);
        Task Add(Payment payment);
        Task Update(Payment payment);
        Task Delete(Payment payment);
        Task<int> GetTodayCount(DateTime date);
    }
}
