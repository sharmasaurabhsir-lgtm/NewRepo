using PaymentPortal.DTOs;
using PaymentPortal.Models;
using PaymentPortal.Repositories;

namespace PaymentPortal.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repo;

        public PaymentService(IPaymentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Payment> CreatePayment(CreatePaymentDto dto)
        {
            // Duplicate Check
            var existing = await _repo.GetByClientRequestId(dto.ClientRequestId);
            if (existing != null)
                return existing;

            // Validation
            if (dto.Amount <= 0)
                throw new Exception("Amount must be > 0");

            var allowedCurrencies = new[] { "USD", "EUR", "INR", "GBP" };
            if (!allowedCurrencies.Contains(dto.Currency))
                throw new Exception("Invalid currency");

            var today = DateTime.UtcNow;
            var count = await _repo.GetTodayCount(today) + 1;

            var reference = $"PAY-{today:yyyyMMdd}-{count:D4}";

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                Amount = dto.Amount,
                Currency = dto.Currency,
                ClientRequestId = dto.ClientRequestId,
                CreatedAt = today,
                Reference = reference
            };

            await _repo.Add(payment);
            return payment;
        }

        public async Task<List<Payment>> GetAll()
            => await _repo.GetAll();

        public async Task<Payment> Update(Guid id, UpdatePaymentDto dto)
        {
            var payment = await _repo.GetById(id);
            if (payment == null) return null;

            payment.Amount = dto.Amount;
            payment.Currency = dto.Currency;

            await _repo.Update(payment);
            return payment;
        }

        public async Task<bool> Delete(Guid id)
        {
            var payment = await _repo.GetById(id);
            if (payment == null) return false;

            await _repo.Delete(payment);
            return true;
        }
    }
}
