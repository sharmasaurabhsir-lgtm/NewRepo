namespace PaymentPortal.DTOs
{
    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string ClientRequestId { get; set; }
    }
}
