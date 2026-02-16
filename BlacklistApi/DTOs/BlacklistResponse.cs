namespace BlacklistApi.DTOs;

public class BlacklistResponse
{
    public Guid Id { get; set; }
    public string CarName { get; set; }
    public string Reason { get; set; }
    public DateTime CreatedAt { get; set; }

}
