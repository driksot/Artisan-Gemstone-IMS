namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class SnapshotResponse
{
    public List<SnapshotVM> InventorySnapshots { get; set; } = new();
    public List<DateTime> Timeline { get; set; } = new();
}
