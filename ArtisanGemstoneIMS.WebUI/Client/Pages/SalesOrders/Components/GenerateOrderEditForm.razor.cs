using ArtisanGemstoneIMS.Application.SalesOrders.Commands;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders.Components;

public partial class GenerateOrderEditForm
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    [Inject]
    public IProductsClient ProductsClient { get; set; } = null!;

    [Inject]
    public IInventoriesClient InventoriesClient { get; set; } = null!;

    [Inject]
    public ISalesOrdersClient SalesOrdersClient { get; set; } = null!;

    [Inject]
    public ICustomersClient CustomersClient { get; set; } = null!;

    [Inject]
    public IMapper Mapper { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    private List<CustomersListDto> Customers = new List<CustomersListDto>();
    private List<ProductsListDto> Products = new List<ProductsListDto>();
    private List<LineItemDto> LineItems = new List<LineItemDto>();
    private List<LineItemDto> selectedLineItems = new List<LineItemDto>();
    private SalesOrderDetailsDto Order = new SalesOrderDetailsDto();
    private CustomersListDto selectedCustomer = new CustomersListDto();
    private LineItemDto selectedLineItem = new LineItemDto();
    private InventoryDetailsDto selectedInventory = new InventoryDetailsDto();

    protected override async Task OnInitializedAsync()
    {
        Customers = (await CustomersClient.GetAllAsync()).ToList();
        await GetProducts();

        if (LineItems.Count > 0)
            selectedLineItem = LineItems[0];
    }

    private async Task HandleValidSubmit()
    {
        // Validate order item quantity is not more than product inventory quantity on hand
        var isAvailabileQuantity = await IsQuantityOnHand(selectedLineItem);

        if (!isAvailabileQuantity)
        {
            // Pop up an alert informing desired quantity is not available
            await JSRuntime.InvokeVoidAsync(
                "alert",
                $"Inventory has insufficient quantity of {selectedInventory.QuantityOnHand}");
            return;
        }

        if (selectedLineItems.Contains(selectedLineItem)) return;

        selectedLineItems.Add(selectedLineItem);

        selectedLineItem = LineItems[0];
    }

    private async Task FinalizeOrder()
    {
        double totalCost = 0;

        foreach (var lineItem in selectedLineItems)
        {
            totalCost += lineItem.UnitPrice * lineItem.Quantity;
        }

        Order.LineItems = selectedLineItems;
        Order.TotalCost = totalCost;
        Order.Customer = Mapper.Map<CustomerDetailsDto>(selectedCustomer);
        //Order.SONumber = 

        var generateOrder = Mapper.Map<GenerateOrderCommand>(Order);
        await SalesOrdersClient.GenerateOrderAsync(generateOrder);

        NavigationManager.NavigateTo("/orders");
    }

    private async Task GetProducts()
    {
        Products = (await ProductsClient.GetUnarchivedAsync()).ToList();

        if (Products.Count == 0) return;

        foreach (var product in Products)
        {
            var item = new LineItemDto
            {
                Product = Mapper.Map<ProductDetailsDto>(product),
                UnitPrice = product.Price
            };

            LineItems.Add(item);
        }
    }

    private async Task<bool> IsQuantityOnHand(LineItemDto lineItem)
    {
        var product = lineItem.Product;
        selectedInventory = await InventoriesClient.GetByProductIdAsync(product.Id);
        var inventoryQuantityOnHand = selectedInventory.QuantityOnHand;
        var currentQuantity = 0;

        foreach (var item in selectedLineItems)
        {
            if (item.Id == lineItem.Id)
            {
                currentQuantity += item.Quantity;
            }
        }

        if (lineItem.Quantity + currentQuantity > inventoryQuantityOnHand)
            return false;

        return true;
    }
}