namespace ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;

public class BaseSalesOrderDto
{
    public string SONumber { get; set; } = string.Empty;

    public Guid CustomerId { get; set; }

    public bool IsPaid { get; set; } = false;

    public double TotalCost { get; set; }


    public ICollection<BaseLineItemDto> LineItems { get; set; } = new List<BaseLineItemDto>();
}
