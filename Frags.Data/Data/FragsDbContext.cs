using Frags.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Frags.Data.Data;

public class FragsDbContext : IdentityDbContext<IdentityUser>
{
    public FragsDbContext(DbContextOptions<FragsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Fragrance> Fragrances { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Fresh" },
            new Category { Id = 2, Name = "Floral" },
            new Category { Id = 3, Name = "Woody" },
            new Category { Id = 4, Name = "Oriental" }
        );

        builder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Dior" },
            new Brand { Id = 2, Name = "Yves Saint Laurent" },
            new Brand { Id = 3, Name = "Tom Ford" }
        );

        builder.Entity<Fragrance>().HasData(
            new Fragrance
            {
                Id = 1,
                Name = "Sauvage",
                Price = 120,
                ImageUrl = "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.31861.avif",
                Description = "A fresh spicy fragrance.",
                Gender = "Men",
                CategoryId = 1,
                BrandId = 1
            },
            new Fragrance
            {
                Id = 2,
                Name = "Libre",
                Price = 140,
                ImageUrl = "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.65936.avif",
                Description = "A white floral fragrance.",
                Gender = "Women",
                CategoryId = 2,
                BrandId = 2
            },
            new Fragrance
            {
                Id = 3,
                Name = "Oud Wood",
                Price = 215,
                ImageUrl = "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.1826.avif",
                Description = "A woody fragrance.",
                Gender = "Unisex",
                CategoryId = 3,
                BrandId = 3
            },
            new Fragrance
            {
                Id = 4,
                Name = "Black Opium",
                Price = 130,
                ImageUrl = "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.25324.avif",
                Description = "An oriental vanilla fragrance.",
                Gender = "Women",
                CategoryId = 4,
                BrandId = 2
            }
        );

        builder.Entity<Contact>().HasData(
        new Contact
        {
            Id = 1,
            Email = "alexanderisaev@abv.bg",
            Phone = "+359888123456"
        }
);
    }
}
