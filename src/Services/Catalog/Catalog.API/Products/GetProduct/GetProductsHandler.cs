namespace Catalog.API.Products.GetProduct
{
    public record GetProductQuery(): IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsHandler (IDocumentSession session, ILogger<GetProductsHandler> logger)
        : IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsHandler: Handling GetProductQuery {@Query}",query);

            var products = await session
                .Query<Product>()
                .ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
