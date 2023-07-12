using ArtisanGemstoneIMS.Domain.Common;
using ArtisanGemstoneIMS.Domain.Products;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Inventories;

public class InventorySnapshot : AuditableEntity
{
    public Product? Product { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public DateTime SnapshotTime { get; set; }

    [Required]
    public int SnapshotQuantity { get; set; }
}
