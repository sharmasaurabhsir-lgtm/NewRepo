namespace PaymentPortal.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ClientRequestId { get; set; }
    }
}
