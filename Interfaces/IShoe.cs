namespace ShoeShack.Interfaces
{
  public interface IShoe
  {
    string Name { get; set; }
    string Description { get; set; }
    string Color { get; set; }
    decimal Size { get; set; }
    decimal Price { get; set; }
    int BrandId { get; set; }
  }
}