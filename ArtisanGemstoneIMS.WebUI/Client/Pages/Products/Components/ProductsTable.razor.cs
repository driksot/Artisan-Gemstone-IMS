using ArtisanGemstoneIMS.WebUI.Shared.Products;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Products.Components;

public partial class ProductsTable
{
    [Inject]
    public IProductsClient ProductsClient { get; set; } = null!;

    private string searchString = "";
    private ProductsListDto selectedProduct = new ProductsListDto();
    private IEnumerable<ProductsListDto> Products = new List<ProductsListDto>();

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductsClient.GetAllAsync();
    }

    private bool FilterFunc(ProductsListDto product) => FilterFunction(product, searchString);

    private bool FilterFunction(ProductsListDto product, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (product.Sku.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (product.Price.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{product.Sku} {product.Name} {product.Price}".Contains(searchString))
            return true;
        return false;
    }
}