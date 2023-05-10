using ArtisanGemstoneIMS.Domain.Products;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.SalesOrders;

public class LineItem
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public double UnitPrice { get; set; }

    public Product? Product { get; set; }

    [Required]
    public Guid ProductId { get; set; }
}
