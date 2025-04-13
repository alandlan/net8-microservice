
namespace Catalog.API.Products.GetProduct
{
    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductsReponse(IEnumerable<Product> Products);

    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var query = request.Adapt<GetProductQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductsReponse>();

                return Results.Ok(response);
            }).WithName("GetProducts")
              .Produces<GetProductsReponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status500InternalServerError)
              .WithSummary("Get Products")
              .WithDescription("Get all products from the catalog");
        }
    }
}
