using BookHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "System Administrator",
                CreatedOn = new DateTime(2026, 1, 1),
                CreatedBy = "System"
            },
            new Role
            {
                Id = 2,
                Name = "Customer",
                Description = "Book Store Customer",
                CreatedOn = new DateTime(2026, 1, 1),
                CreatedBy = "System"
            });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Role> Roles => Set<Role>();
}