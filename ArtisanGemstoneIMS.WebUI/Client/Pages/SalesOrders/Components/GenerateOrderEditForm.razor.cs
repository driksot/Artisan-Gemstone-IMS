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

    private List<CustomerDetailsDto> Customers = new List<CustomerDetailsDto>();
    private List<ProductsListDto> Products = new List<ProductsListDto>();
    private List<LineItemDto> LineItems = new List<LineItemDto>();
    private SalesOrderDetailsDto Order = new SalesOrderDetailsDto();
    private LineItemDto selectedLineItem = new LineItemDto();
    private InventoryDetailsDto selectedInventory = new InventoryDetailsDto();

    protected override async Task OnInitializedAsync()
    {
        var customerList = (await CustomersClient.GetAllAsync()).ToList();
        Customers = Mapper.Map<List<CustomerDetailsDto>>(customerList);
        await GetProducts();

        if (LineItems.Count > 0)
            selectedLineItem = LineItems[0];
    }

    private async Task HandleValidSubmit()
    {
        var isValidOrder = await IsOrderValid(Order);

        if (!isValidOrder)
        {
            await JSRuntime.InvokeVoidAsync(
                "alert",
                "Sales Order is incomplete. Please verify there is an Order #, a customer is selected and line items have been added.");
            return;
        }

        double totalCost = 0;

        foreach (var lineItem in Order.LineItems)
        {
            totalCost += lineItem.UnitPrice * lineItem.Quantity;
            if (lineItem.Product != null)
                lineItem.ProductId = lineItem.Product.Id;
        }

        Order.TotalCost = totalCost;
        Order.CustomerId = Order.Customer.Id;


        var generateOrder = Mapper.Map<GenerateOrderCommand>(Order);
        await SalesOrdersClient.GenerateOrderAsync(generateOrder);

        NavigationManager.NavigateTo("/orders");
    }

    private async Task AddLineItem()
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

        if (selectedLineItem.Quantity == 0)
        {
            Order.LineItems.Remove(selectedLineItem);
            return;
        }

        if (Order.LineItems.Contains(selectedLineItem)) return;

        Order.LineItems.Add(selectedLineItem);

        selectedLineItem = LineItems[0];
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

        if (lineItem.Quantity > inventoryQuantityOnHand)
        {
            return false;
        }

        return true;
    }

    private async Task<bool> IsOrderValid(SalesOrderDetailsDto order)
    {
        if (order == null) return false;
        if (order.Customer == null) return false;
        if (order.LineItems.Count == 0) return false;

        return true;
    }
}