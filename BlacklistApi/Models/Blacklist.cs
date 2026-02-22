using System.ComponentModel.DataAnnotations;

namespace BlacklistApi.Models;

public class Blacklist
{
    [Required]
    [Key]
    public Guid Id { get; init; }
    [Required]
    [StringLength(50)]
    public string CarName { get; set; }
    [Required]
    [StringLength(300)]
    public string Reason { get; set; }
    public DateTime CreatedAt { get; set; }
}

