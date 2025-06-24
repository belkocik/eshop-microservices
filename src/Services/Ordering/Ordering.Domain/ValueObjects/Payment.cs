namespace Ordering.Domain.ValueObjects;

public record Payment
{
  protected Payment()
  {
  }

  private Payment(string cardName, string cardNumber, string expiration, string cvv, string paymentMethod)
  {
    CardName = cardName;
    CardNumber = cardNumber;
    Expiration = expiration;
    CVV = cvv;
    PaymentMethod = paymentMethod;
  }

  public string? CardName { get; }
  public string CardNumber { get; } = null!;
  public string Expiration { get; } = null!;
  public string CVV { get; } = null!;
  public string PaymentMethod { get; } = null!;

  public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, string paymentMethod)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
    ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
    ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
    ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);
    return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
  }
}