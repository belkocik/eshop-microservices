namespace Basket.API.Models;

public class ShoppingCart
{
  public ShoppingCart(string userName)
  {
    UserName = userName;
  }

  // Required for mapping
  public ShoppingCart()
  {
  }

  public string UserName { get; set; } = null!;
  public List<ShoppingCartItem> Items { get; set; } = [];
  public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}