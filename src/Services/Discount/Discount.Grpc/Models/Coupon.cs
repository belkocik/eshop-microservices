namespace Discount.Grpc.Models;

public class Coupon
{
  public Coupon()
  {
  }

  public Coupon(int id, string productName, string description)
  {
    Id = id;
    ProductName = productName;
    Description = description;
  }

  public int Id { get; set; }
  public string ProductName { get; set; } = null!;
  public string Description { get; set; } = null!;
  public int Amount { get; set; }
}