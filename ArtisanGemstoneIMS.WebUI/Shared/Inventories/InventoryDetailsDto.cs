using ArtisanGemstoneIMS.WebUI.Shared.Products;

namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class InventoryDetailsDto
{
    public Guid Id { get; set; }
    public ProductDetailsDto Product { get; set; } = new ProductDetailsDto();
    public int QuantityOnHand { get; set; }
    public int IdealQuantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
