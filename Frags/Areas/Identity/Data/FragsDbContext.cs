using Frags.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Frags.Areas.Identity.Data;

public class FragsDbContext : IdentityDbContext<IdentityUser>
{
    public FragsDbContext(DbContextOptions<FragsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Fragrance> Fragrances { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
