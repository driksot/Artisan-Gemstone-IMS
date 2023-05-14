using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders.Components;

public partial class LineItemsTable
{
    [Parameter]
    public List<LineItemDto> ItemList { get; set; } = new List<LineItemDto>();

    [Parameter]
    public EventCallback OnTableRefresh { get; set; }

    private async Task TableRefresh()
    {
        await OnTableRefresh.InvokeAsync();
    }
}