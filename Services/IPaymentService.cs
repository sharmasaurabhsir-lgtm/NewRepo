using PaymentPortal.DTOs;
using PaymentPortal.Models;

namespace PaymentPortal.Services
{
    public interface IPaymentService
    {
        Task<Payment> CreatePayment(CreatePaymentDto dto);
        Task<List<Payment>> GetAll();
        Task<Payment> Update(Guid id, UpdatePaymentDto dto);
        Task<bool> Delete(Guid id);
    }
}
