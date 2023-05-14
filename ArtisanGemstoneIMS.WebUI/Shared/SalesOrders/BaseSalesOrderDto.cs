using ArtisanGemstoneIMS.WebUI.Shared.Customers;

namespace ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;

public class BaseSalesOrderDto
{
    public string SONumber { get; set; } = string.Empty;

    public CustomerDetailsDto? Customer { get; set; }

    public bool IsPaid { get; set; } = false;

    public double TotalCost { get; set; }


    public ICollection<LineItemDto> LineItems { get; set; } = new List<LineItemDto>();
}
