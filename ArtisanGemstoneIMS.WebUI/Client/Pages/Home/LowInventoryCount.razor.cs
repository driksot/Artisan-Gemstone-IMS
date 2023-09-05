using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Home;

public partial class LowInventoryCount
{
    [Inject]
    public IInventoriesClient InventoriesClient { get; set; } = null!;

    private int Count = 0;

    protected override async Task OnInitializedAsync()
    {
        var lowInventories = await InventoriesClient.GetLowStockAsync();
        Count = lowInventories.Count;
    }
}