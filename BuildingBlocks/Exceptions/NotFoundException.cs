namespace BuildingBlocks.Exceptions;

public class NotFoundException : Exception
{
  public NotFoundException(string message) : base(message)
  {
  }

  protected NotFoundException(string name, object key)
    : base($"Entity: {name} with key: {key} not found.")
  {
  }
}