using System.ComponentModel.DataAnnotations;

namespace BlacklistApi.DTOs;

public class CreateBlacklistRequest
{
    public string CarName { get; set; }
    public string Reason { get; set; }
}
