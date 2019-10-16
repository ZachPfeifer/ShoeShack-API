namespace ShoeShack.Interfaces
{
  public interface IItem
  {
    string Name { get; set; }
    string Description { get; set; }
    string Color { get; set; }
    decimal Size { get; set; }
    decimal Price { get; set; }
  }
}