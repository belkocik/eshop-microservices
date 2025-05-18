using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
  string Name,
  string Description,
  string ImageFile,
  decimal Price,
  List<string> Category) : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
  public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
  {
    // business logic to create a product
    throw new NotImplementedException();
  }
}