namespace Ordering.Domain.ValueObjects
{
    public record OrderItemId
    {
        public Guid Value { get; set; }

        // Adding the missing 'Of' method to fix the error CS0117  
        public static OrderItemId Of(Guid value)
        {
            return new OrderItemId { Value = value };
        }
    }
}
