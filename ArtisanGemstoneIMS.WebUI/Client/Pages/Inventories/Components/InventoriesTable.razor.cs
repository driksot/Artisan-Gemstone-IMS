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

    private async void ItemHasBeenCommitted(object inventory)
    {
        AddEditionEvent($"RowEditCommit event: Changes to Inventory {((InventoriesListDto)inventory).Product.Name}");

        var currentInventory = (await InventoriesClient.GetAllAsync()).Single(i => i.Id == (((InventoriesListDto)inventory).Id));

        var qohAdjustment = currentInventory.QuantityOnHand < ((InventoriesListDto)inventory).QuantityOnHand
            ? ((InventoriesListDto)inventory).QuantityOnHand - currentInventory.QuantityOnHand
            : (currentInventory.QuantityOnHand - ((InventoriesListDto)inventory).QuantityOnHand) * -1;

        var idealAdjustment = currentInventory.IdealQuantity < ((InventoriesListDto)inventory).IdealQuantity
            ? ((InventoriesListDto)inventory).IdealQuantity - currentInventory.IdealQuantity
            : (currentInventory.IdealQuantity - ((InventoriesListDto)inventory).IdealQuantity) * -1;

        AdjustCurrentStock(
            new InventoryAdjustmentDto
            {
                InventoryId = currentInventory.Id,
                Adjustment = qohAdjustment
            }
        );

        AdjustIdealStock(
            new InventoryAdjustmentDto
            {
                InventoryId = currentInventory.Id,
                Adjustment = idealAdjustment
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
        //Console.WriteLine("Current Adjustment = " + inventoryAdjustment.Adjustment);

        InventoriesClient.UpdateQuantityOnHandAsync(inventoryAdjustment);
    }

    private void AdjustIdealStock(InventoryAdjustmentDto inventoryAdjustmentDto)
    {
        //Console.WriteLine("Adjustment = " + inventoryAdjustmentDto.Adjustment);
        //Console.WriteLine(inventoryAdjustmentDto.Adjustment.ToString());

        InventoriesClient.UpdateIdealQuantityAsync(inventoryAdjustmentDto);
    }
}