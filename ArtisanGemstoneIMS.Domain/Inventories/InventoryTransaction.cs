using ArtisanGemstoneIMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Inventories;

public class InventoryTransaction : AuditableEntity
{
    public string PONumber { get; set; } = string.Empty;

    public string SONumber { get; set; } = string.Empty;

    public Inventory? Inventory { get; set; }

    [Required]
    public Guid InventoryId { get; set; }

    [Required]
    public InventoryTransactionType TransactionType { get; set; }

    [Required]
    public int QuantityBefore { get; set; }

    [Required]
    public int QuantityAfter { get; set; }

    [Required]
    public DateTime TransactionDate { get; set; }
}
