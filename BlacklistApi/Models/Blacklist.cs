using System.ComponentModel.DataAnnotations;

namespace BlacklistApi.Models;

public class Blacklist
{
    public Guid Id { get; set; }
    public string CarName { get; set; }
    public string Reason { get; set; }
    public DateTime CreatedAt { get; set; }
}

