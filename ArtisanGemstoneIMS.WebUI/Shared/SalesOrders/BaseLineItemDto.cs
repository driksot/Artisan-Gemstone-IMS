namespace ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;

public class BaseLineItemDto
{
    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public Guid ProductId { get; set; }
}
