using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Common;

public abstract class AuditableEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }
}
