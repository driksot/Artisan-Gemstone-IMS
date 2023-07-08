using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Home;

public partial class ProductCount
{
    [Inject]
    public IProductsClient ProductsClient { get; set; } = null!;

    private int Count = 0;

    protected override async Task OnInitializedAsync()
    {
        var products = await ProductsClient.GetUnarchivedAsync();
        Count = products.Count();
    }
}