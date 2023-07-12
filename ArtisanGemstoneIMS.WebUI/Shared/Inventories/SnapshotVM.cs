namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class SnapshotVM
{
    public List<int> QuantityOnHand { get; set; } = new();
    public Guid ProductId { get; set; }
}
