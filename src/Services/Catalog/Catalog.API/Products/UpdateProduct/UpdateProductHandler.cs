﻿

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name,List<string> Category, string Description, string ImageUrl, decimal Price) 
        : ICommand<UpdateProductResult>;

    public class UpdateProductResult(bool IsSuccess);
    internal class UpdateProductHandler 
        (IDocumentSession session, ILogger<UpdateProductHandler> logger)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductHandler.Handle called with {@Command}", command);

            var product = await session.LoadAsync<Product>(command.Id);

            if (product is null)
                throw new ProductNotFoundException();
            
            product.Name = command.Name;
            product.Description = command.Description;
            product.ImageFile = command.ImageUrl;
            product.Price = command.Price;
            product.Category = command.Category;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
