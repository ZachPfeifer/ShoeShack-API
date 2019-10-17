using ShoeShack.Interfaces;

namespace ShoeShack.Models
{
  public class Order : IOrder
  {
    public int Id { get; set; }
    public string CustomerName { get; set; }
  }
}