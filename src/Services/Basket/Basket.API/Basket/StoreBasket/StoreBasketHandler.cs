namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
  public StoreBasketCommandValidator()
  {
    RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
    RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
  }
}

public class StoreBasketCommandHandler(IBasketRepository repository)
  : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
  public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
  {
    var Cart = command.Cart;
    // todo: store basket in database (use Marten upsert - if exist = update, if not = create)
    await repository.StoreBasket(command.Cart, cancellationToken);
    // todo: update cache
    return new StoreBasketResult(command.Cart.UserName);
  }
}