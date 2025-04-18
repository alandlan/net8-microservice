﻿

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name,List<string> Category, string Description, string ImageUrl, decimal Price) 
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }

    internal class UpdateProductHandler 
        (IDocumentSession session)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id);

            if (product is null)
                throw new ProductNotFoundException(command.Id);
            
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
