using ArtisanGemstoneIMS.Domain.Common;
using ArtisanGemstoneIMS.Domain.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtisanGemstoneIMS.Domain.SalesOrders;

public class SalesOrder : AuditableEntity
{
    [Required]
    public string SONumber { get; set; } = string.Empty;

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public bool IsPaid { get; set; } = false;

    [Required]
    public double TotalCost { get; set; }


    public ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
}
