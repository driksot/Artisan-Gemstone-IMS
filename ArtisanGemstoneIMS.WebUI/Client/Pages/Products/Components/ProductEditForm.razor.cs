using ArtisanGemstoneIMS.WebUI.Shared.Products;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Products.Components;

public partial class ProductEditForm
{
    [Parameter]
    public ProductDetailsDto Product { get; set; } = null!;
    [Parameter]
    public EventCallback<ProductDetailsDto> OnValidSubmit { get; set; }

    public async Task HandleValidSubmit()
    {
        await OnValidSubmit.InvokeAsync(Product);
    }
}