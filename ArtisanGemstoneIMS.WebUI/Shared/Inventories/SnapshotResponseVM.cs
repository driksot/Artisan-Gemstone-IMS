namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class SnapshotResponseVM
{
    public SnapshotChartVM[] InventorySnapshots { get; set; } = new SnapshotChartVM[0];
    public DateTime[] Timeline { get; set; } = new DateTime[0];
}
