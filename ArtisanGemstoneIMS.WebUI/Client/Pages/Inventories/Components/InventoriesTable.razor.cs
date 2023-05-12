using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Inventories.Components;

public partial class InventoriesTable
{
    [Inject]
    public IInventoriesClient InventoriesClient { get; set; } = null!;

    private string searchString = "";
    private InventoriesListDto selectedInventory = new InventoriesListDto();
    private IEnumerable<InventoriesListDto> Inventories = new List<InventoriesListDto>();
    private List<string> editEvents = new List<string>();
    private InventoriesListDto inventoryBeforeEdit = new InventoriesListDto();

    protected override async Task OnInitializedAsync()
    {
        Inventories = await InventoriesClient.GetAllAsync();
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

    private void ClearEventLog()
    {
        editEvents.Clear();
    }

    private void AddEditionEvent(string message)
    {
        editEvents.Add(message);
        StateHasChanged();
    }

    private void BackupItem(object inventory)
    {
        inventoryBeforeEdit = new()
        {
            QuantityOnHand = ((InventoriesListDto)inventory).QuantityOnHand,
            IdealQuantity = ((InventoriesListDto)inventory).IdealQuantity
        };
        AddEditionEvent($"RowEditPreview event: made a backup of Inventory {((InventoriesListDto)inventory).Product.Name}");
    }

    private void ItemHasBeenCommitted(object inventory)
    {
        AddEditionEvent($"RowEditCommit event: Changes to Inventory {((InventoriesListDto)inventory).Product.Name}");

        AdjustCurrentStock(
            new InventoryAdjustmentDto
            {
                InventoryId = ((InventoriesListDto)inventory).Id,
                Adjustment = ((InventoriesListDto)inventory).QuantityOnHand
            }
        );

        AdjustIdealStock(
            new InventoryAdjustmentDto
            {
                InventoryId = ((InventoriesListDto)inventory).Id,
                Adjustment = ((InventoriesListDto)inventory).IdealQuantity
            }
        );
    }

    private void ResetItemToOriginalValues(object inventory)
    {
        ((InventoriesListDto)inventory).QuantityOnHand = inventoryBeforeEdit.QuantityOnHand;
        ((InventoriesListDto)inventory).IdealQuantity = inventoryBeforeEdit.IdealQuantity;
        AddEditionEvent($"RowEditCancel event: Editing of Inventory {((InventoriesListDto)inventory).Product.Name} cancelled");
    }

    private void AdjustCurrentStock(InventoryAdjustmentDto inventoryAdjustment)
    {
        InventoriesClient.UpdateQuantityOnHandAsync(inventoryAdjustment);
    }

    private void AdjustIdealStock(InventoryAdjustmentDto inventoryAdjustmentDto)
    {
        InventoriesClient.UpdateIdealQuantityAsync(inventoryAdjustmentDto);
    }
}