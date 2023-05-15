using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders.Components;

public partial class OrderSummaryTable
{
    [Parameter]
    public List<LineItemDto> ItemList { get; set; } = new List<LineItemDto>();

    [Parameter]
    public double GrandTotal { get; set; }

    [Inject]
    public IProductsClient ProductsClient { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        foreach (var item in ItemList)
        {
            item.Product = await ProductsClient.GetByIdAsync(item.ProductId);
        }
    }
}