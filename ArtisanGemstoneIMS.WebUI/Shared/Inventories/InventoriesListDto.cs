using ArtisanGemstoneIMS.WebUI.Shared.Products;

namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class InventoriesListDto
{
    public Guid Id { get; set; }
    public ProductDetailsDto Product { get; set; } = new ProductDetailsDto();
    public int QuantityOnHand { get; set; }
    public int IdealQuantity { get; set; }
}
