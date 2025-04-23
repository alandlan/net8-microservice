namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; init; } = default!;
        public string CardNumber { get; init; } = default!;
        public string Expiration { get; init; } = default!;
        public string Cvv { get; init; } = default!;
        public decimal PaymentMethod { get; init; } = default!;
    }
}
