namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
  string Name,
  string Description,
  string ImageFile,
  decimal Price,
  List<string> Category) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
  public CreateProductCommandValidator()
  {
    RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
    RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required.");
    RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
  }
}

internal class CreateProductCommandHandler(IDocumentSession session)
  : ICommandHandler<CreateProductCommand, CreateProductResult>
{
  public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
  {
    // 1. business logic to create a product
    var product = new Product
    {
      Name = command.Name,
      Category = command.Category,
      Description = command.Description,
      ImageFile = command.ImageFile,
      Price = command.Price
    };
    // 2. save to a database
    session.Store(product);
    await session.SaveChangesAsync(cancellationToken);
    // 3. return CreateProductResult
    return new CreateProductResult(product.Id);
  }
}