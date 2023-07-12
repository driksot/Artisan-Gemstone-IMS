using ArtisanGemstoneIMS.WebUI.Shared.Products;

namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class SnapshotDto
{
    public Guid Id { get; set; }
    public ProductDetailsDto Product { get; set; } = new ProductDetailsDto();
    public DateTime SnapshotTime { get; set; }
    public int SnapshotQuantity { get; set; }
}
