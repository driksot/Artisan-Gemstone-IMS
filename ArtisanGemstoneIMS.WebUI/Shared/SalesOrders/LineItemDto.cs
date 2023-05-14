using ArtisanGemstoneIMS.WebUI.Shared.Products;

namespace ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;

public class LineItemDto
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public ProductDetailsDto? Product { get; set; }
}
