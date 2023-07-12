namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class InventoryTransactionDto
{
    public Guid Id { get; set; }
    public string PONumber { get; set; } = string.Empty;
    public string SONumber { get; set; } = string.Empty;
    public InventoryDetailsDto? Inventory { get; set; }
    public Guid InventoryId { get; set; }
    public TransactionTypeDto TransactionType { get; set; }
    public int QuantityBefore { get; set; }
    public int QuantityAfter { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
