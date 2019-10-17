using System.ComponentModel.DataAnnotations;
using ShoeShack.Interfaces;

namespace ShoeShack.Models
{
  public class Shoe : IShoe
  {
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public decimal Size { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
  }
}