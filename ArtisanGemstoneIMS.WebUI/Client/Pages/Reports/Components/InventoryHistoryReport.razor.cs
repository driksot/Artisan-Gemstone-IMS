using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Reports.Components;

public partial class InventoryHistoryReport
{
    [Inject]
    public IInventoriesClient InventoriesClient { get; set; } = null!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    private string searchString = "";
    private IEnumerable<SnapshotDto> Snapshots = new List<SnapshotDto>();

    protected override async Task OnInitializedAsync()
    {
        Snapshots = await InventoriesClient.GetSnapshotReportAsync(5);
    }

    private bool FilterFunc(SnapshotDto snapshot) => FilterFunction(snapshot, searchString);

    private bool FilterFunction(SnapshotDto snapshot, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (snapshot.Product.Sku.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (snapshot.Product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (snapshot.SnapshotTime.ToShortTimeString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (snapshot.SnapshotQuantity.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{snapshot.Product.Sku} {snapshot.Product.Name} {snapshot.SnapshotTime} {snapshot.SnapshotQuantity}".Contains(searchString))
            return true;
        return false;
    }

    private async Task PrintReport()
    {
        await JSRuntime.InvokeVoidAsync("print");
    }
}