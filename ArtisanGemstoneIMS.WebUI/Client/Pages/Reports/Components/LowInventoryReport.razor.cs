using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Reports.Components;

public partial class LowInventoryReport
{
    [Inject]
    public IInventoriesClient InventoriesClient { get; set; } = null!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    private string searchString = "";
    private InventoriesListDto selectedInventory = new InventoriesListDto();
    private IEnumerable<InventoriesListDto> Inventories = new List<InventoriesListDto>();

    protected override async Task OnInitializedAsync()
    {
        Inventories = await InventoriesClient.GetLowStockAsync();
    }

    private bool FilterFunc(InventoriesListDto inventory) => FilterFunction(inventory, searchString);

    private bool FilterFunction(InventoriesListDto inventory, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (inventory.Product.Sku.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (inventory.Product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (inventory.Product.Price.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (inventory.QuantityOnHand.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (inventory.IdealQuantity.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{inventory.Product.Sku} {inventory.Product.Name} {inventory.Product.Price} {inventory.QuantityOnHand} {inventory.IdealQuantity}".Contains(searchString))
            return true;
        return false;
    }

    private async Task PrintReport()
    {
        await JSRuntime.InvokeVoidAsync("print");
    }
}