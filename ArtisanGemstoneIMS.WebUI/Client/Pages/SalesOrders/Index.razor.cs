using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders;

public partial class Index
{
    [Inject]
    public ISalesOrdersClient SalesOrdersClient { get; set; } = null!;

    private IEnumerable<SalesOrdersListDto> OpenOrders = new List<SalesOrdersListDto>();
    private IEnumerable<SalesOrdersListDto> ClosedOrders = new List<SalesOrdersListDto>();

    public void CompleteOrder()
    {
        StateHasChanged();
    }
}