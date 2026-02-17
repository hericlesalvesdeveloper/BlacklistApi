using BlacklistApi.DTOs;
using BlacklistApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlacklistApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlacklistController : ControllerBase
{
    private static List<Blacklist> blacklists = new List<Blacklist>();

    [HttpPost]
    public ActionResult<CreateBlacklistRequest> Create(CreateBlacklistRequest createBlacklist)
    {

        // DTO -> Entity
        var entidade = new Blacklist
        {
            Id = Guid.NewGuid(),
            CarName = createBlacklist.CarName,
            Reason = createBlacklist.Reason,
            CreatedAt = DateTime.Now
        };

        blacklists.Add(entidade);

        return Ok(entidade);

    }

    [HttpGet("{id}")]
    public ActionResult<BlacklistResponse> GetById(Guid id)
    {
        var entity = blacklists
            .Find(b => b.Id == id);

        if (entity is null) return NotFound();

        // Entity -> DTO
        var response = new BlacklistResponse
        {
            Id = entity.Id,
            CarName = entity.CarName,
            Reason = entity.Reason,
            CreatedAt = entity.CreatedAt

        };

        return Ok(response);
    }

    [HttpGet]
    public ActionResult<IEnumerable<BlacklistResponse>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        // Entity -> DTO
        var response = blacklists.Select(b => new BlacklistResponse
        {
            Id = b.Id,
            CarName = b.CarName,
            Reason = b.Reason,
            CreatedAt = b.CreatedAt
        });

        return Ok(response.Skip(skip).Take(take));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var entity = blacklists
            .FirstOrDefault(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        blacklists.Remove(entity);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Blacklist> Update(Guid id, UpdateBlacklistRequest updateBlacklist)
    {
        var entity = blacklists
            .FirstOrDefault(b => b.Id == id);

        if (entity is null) return NotFound();

        // DTO -> Entity 
        entity.CarName = updateBlacklist.CarName;
        entity.Reason = updateBlacklist.Reason;

        return NoContent();
    }
}
