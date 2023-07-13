using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;

public class PurchaseOrderDto
{
    public Guid Id { get; set; }

    [Required]
    public string PONumber { get; set; } = string.Empty;

    public double TotalCost { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required]
    public ICollection<LineItemDto> LineItems { get; set; } = new List<LineItemDto>();
}
