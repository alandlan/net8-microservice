namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; init; } = default!;
        public string CardNumber { get; init; } = default!;
        public string Expiration { get; init; } = default!;
        public string Cvv { get; init; } = default!;
        public decimal PaymentMethod { get; init; } = default!;

        protected Payment() { } // For EF

        private Payment(string? cardName, string cardNumber, string expiration, string cvv, decimal paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            Cvv = cvv;
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string? cardName, string cardNumber, string expiration, string cvv, decimal paymentMethod)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(cardNumber, nameof(cardNumber));
            ArgumentNullException.ThrowIfNullOrEmpty(expiration, nameof(expiration));
            ArgumentNullException.ThrowIfNullOrEmpty(cvv, nameof(cvv));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3, nameof(cardNumber));

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }

    }
}
