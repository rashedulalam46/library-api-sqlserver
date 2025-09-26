using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    // Example DbSet properties
    // public DbSet<Book> Books { get; set; }
    // public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure entity mappings here
    }
}