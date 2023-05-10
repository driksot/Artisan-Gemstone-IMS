namespace ArtisanGemstoneIMS.WebUI.Shared.Products;

public class ProductsListDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Price { get; set; }
    public bool IsArchived { get; set; } = false;
}
