namespace ArtisanGemstoneIMS.WebUI.Shared.Inventories;

public class SnapshotChartVM
{
    public Guid ProductId { get; set; }
    public double[] QuantityOnHand { get; set; } = new double[0];
}
