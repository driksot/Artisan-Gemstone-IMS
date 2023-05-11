using ArtisanGemstoneIMS.Application.Products.Commands;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Products;

public partial class ProductUpsert
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    [Inject]
    public IProductsClient ProductsClient { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public IMapper Mapper { get; set; } = null!;

    private ProductDetailsDto Product = new ProductDetailsDto();
    private string Title = "Add";

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        if (Id.Length > 1)
        {
            Title = "Edit";
            Product = await ProductsClient.GetByIdAsync(Guid.Parse(Id));
        }
    }

    private async Task HandleValidSubmit(ProductDetailsDto product)
    {
        if (Id.Length > 1)
        {
            var updateProduct = Mapper.Map<UpdateProductCommand>(product);
            await ProductsClient.UpdateAsync(updateProduct);
        }
        else
        {
            var createProduct = Mapper.Map<CreateProductCommand>(product);
            await ProductsClient.CreateAsync(createProduct);
        }

        NavigationManager.NavigateTo("/products");
    }
}