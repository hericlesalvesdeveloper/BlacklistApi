using BlacklistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlacklistApi.Data;

public class BlacklistContext : DbContext
{
    public BlacklistContext(DbContextOptions<BlacklistContext> options)
        : base(options)
    {

    }

    public DbSet<Blacklist> Blacklists { get; set; }

}

