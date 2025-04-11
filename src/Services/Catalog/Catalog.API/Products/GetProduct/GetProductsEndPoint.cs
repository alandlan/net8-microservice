
namespace Catalog.API.Products.GetProduct
{
    public record GetProductsReponse(IEnumerable<Product> Products);

    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(new GetProductQuery());

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
