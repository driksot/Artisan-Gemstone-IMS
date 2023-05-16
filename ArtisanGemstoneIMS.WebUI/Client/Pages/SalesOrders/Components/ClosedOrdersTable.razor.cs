using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders.Components;

public partial class ClosedOrdersTable
{
    [Parameter]
    public IEnumerable<SalesOrdersListDto> Orders { get; set; } = new List<SalesOrdersListDto>();

    [Inject]
    public ISalesOrdersClient SalesOrdersClient { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    private string searchString = "";
    private SalesOrdersListDto selectedOrder = new SalesOrdersListDto();

    protected override async Task OnParametersSetAsync()
    {
        Orders = await SalesOrdersClient.GetClosedOrdersAsync();
    }

    private bool FilterFunc(SalesOrdersListDto order) => FilterFunction(order, searchString);

    private bool FilterFunction(SalesOrdersListDto order, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (order.SONumber.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (order.TotalCost.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (order.UpdatedAt.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{order.SONumber} {order.TotalCost} {order.UpdatedAt}".Contains(searchString))
            return true;
        return false;
    }

    private void NavigateToPreview(Guid id)
    {
        NavigationManager.NavigateTo($"/orders/preview/{id}");
    }
}