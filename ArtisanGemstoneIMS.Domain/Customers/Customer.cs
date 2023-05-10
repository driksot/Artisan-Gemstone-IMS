using ArtisanGemstoneIMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Customers;

public class Customer : AuditableEntity
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(80)]
    public string LastName { get; set; } = string.Empty;

    public Address? PrimaryAddress { get; set; }

    [Required]
    public Guid PrimaryAddressId { get; set; }

    [Required]
    [MaxLength(10)]
    public string? PhoneNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Email { get; set; }
}
