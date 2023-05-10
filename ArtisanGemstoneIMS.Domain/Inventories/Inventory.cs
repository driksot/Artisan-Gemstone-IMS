using ArtisanGemstoneIMS.Domain.Common;
using ArtisanGemstoneIMS.Domain.Products;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Inventories;

public class Inventory : AuditableEntity
{
    public Product? Product { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int QuantityOnHand { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int IdealQuantity { get; set; }
}
