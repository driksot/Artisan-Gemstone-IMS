using ArtisanGemstoneIMS.Domain.Common;
using ArtisanGemstoneIMS.Domain.SalesOrders;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.PurchaseOrders;

public class PurchaseOrder : AuditableEntity
{
    [Required]
    public string PONumber { get; set; } = string.Empty;

    [Required]
    public double TotalCost { get; set; }


    public ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
}
