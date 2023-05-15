using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders;

public partial class PreviewOrder
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    [Inject]
    public ISalesOrdersClient SalesOrdersClient { get; set; } = null!;

    [Inject]
    public ICustomersClient CustomersClient { get; set; } = null!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    private CustomerDetailsDto Customer = new CustomerDetailsDto();
    private SalesOrderDetailsDto Order = new SalesOrderDetailsDto();
    private List<LineItemDto> LineItems = new List<LineItemDto>();
    private double grandTotal;

    protected override async Task OnInitializedAsync()
    {
        Order = await SalesOrdersClient.GetByIdAsync(Guid.Parse(Id));

        foreach (var item in Order.LineItems)
        {
            LineItems.Add(item);
            grandTotal += item.UnitPrice * item.Quantity;
        }

        Customer = await CustomersClient.GetByIdAsync(Order.CustomerId);
    }

    private async Task PrintInvoice()
    {
        await JSRuntime.InvokeVoidAsync("print");
    }
}