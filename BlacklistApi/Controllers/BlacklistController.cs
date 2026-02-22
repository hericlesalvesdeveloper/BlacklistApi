using BlacklistApi.Data;
using BlacklistApi.DTOs;
using BlacklistApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlacklistApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlacklistController : ControllerBase
{

    private BlacklistContext _context;
    public BlacklistController(BlacklistContext context)
    {
         _context = context;
    }

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

        _context.Add(entidade);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = entidade.Id }, entidade);

    }

    [HttpGet("{id}")]
    public ActionResult<BlacklistResponse> GetById(Guid id)
    {
        
        var entity = _context.Blacklists.FirstOrDefault(x => x.Id == id);
            
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
        var response = _context.Blacklists.Select(b => new BlacklistResponse
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
        var entity = _context.Blacklists
            .FirstOrDefault(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        _context.Blacklists.Remove(entity);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Blacklist> Update(Guid id, UpdateBlacklistRequest updateBlacklist)
    {
        var entity = _context.Blacklists
            .FirstOrDefault(b => b.Id == id);

        if (entity is null) return NotFound();

        // DTO -> Entity 
        entity.CarName = updateBlacklist.CarName;
        entity.Reason = updateBlacklist.Reason;
        _context.SaveChanges();
        return NoContent();
    }
}

