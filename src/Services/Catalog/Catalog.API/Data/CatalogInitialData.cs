using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            
            if(await session.Query<Product>().AnyAsync(cancellation))
                return;

            session.Store<Product>(GetPreconfiguredProducts());

            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Description = "Description for Product 1",
                    Price = 10.99M,
                    Category = ["Category1", "Category2"],
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Description = "Description for Product 2",
                    Price = 20.99M,
                    Category = ["Category2", "Category3"],
                }
            };
        }
    }
}
