using ArtisanGemstoneIMS.Domain.Common;
using ArtisanGemstoneIMS.Domain.Customers;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.SalesOrders;

public class SalesOrder : AuditableEntity
{
    public Customer? Customer { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public bool IsPaid { get; set; } = false;

    [Required]
    public double TotalCost { get; set; }


    public ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
}
