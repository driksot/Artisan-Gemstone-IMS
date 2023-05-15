using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders.Components;

public partial class OrderInfoLine
{
    [Parameter]
    public SalesOrderDetailsDto SalesOrder { get; set; } = new SalesOrderDetailsDto();
}