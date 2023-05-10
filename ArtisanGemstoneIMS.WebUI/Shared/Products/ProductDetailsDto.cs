namespace ArtisanGemstoneIMS.WebUI.Shared.Products;

public class ProductDetailsDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Price { get; set; }
    public bool IsArchived { get; set; } = false;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
