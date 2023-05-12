namespace ArtisanGemstoneIMS.WebUI.Shared.Customers;

public class CustomersListDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public AddressDto PrimaryAddress { get; set; } = new();
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
}
