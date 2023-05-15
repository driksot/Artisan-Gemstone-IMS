using ArtisanGemstoneIMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Products;

public class Product : AuditableEntity
{
    private const int _defaultSkuLength = 15;

    [Range(_defaultSkuLength, _defaultSkuLength)]
    public string Sku { get; set; } = string.Empty;

    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Description { get; set; }

    [Range(0, int.MaxValue)]
    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsArchived { get; set; } = false;
}
