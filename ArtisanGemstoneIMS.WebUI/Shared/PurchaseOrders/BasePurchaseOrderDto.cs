using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;

namespace ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;

public class BasePurchaseOrderDto
{
    public string PONumber { get; set; } = string.Empty;

    public double TotalCost { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }


    public ICollection<LineItemDto> LineItems { get; set; } = new List<LineItemDto>();
}
