using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("E3678D94-F208-4172-997E-CBCE78D3B990")),"User 1", "user1@email.com"),
            Customer.Create(CustomerId.Of(new Guid("044F58EF-1A54-4B10-9AAA-D4175C5B5136")),"User 2", "user2@email.com"),
        };
    }
}
