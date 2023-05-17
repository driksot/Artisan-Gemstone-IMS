using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;

public class SalesOrderDetailsDto
{
    public Guid Id { get; set; }

    [Required]
    public string SONumber { get; set; } = string.Empty;

    [Required]
    public Guid CustomerId { get; set; }

    public CustomerDetailsDto Customer { get; set; } = new CustomerDetailsDto();

    public bool IsPaid { get; set; } = false;

    public double TotalCost { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required]
    public ICollection<LineItemDto> LineItems { get; set; } = new List<LineItemDto>();
}
