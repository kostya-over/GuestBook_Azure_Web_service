using Microsoft.EntityFrameworkCore;

namespace GuestBook;

public partial class GuestBookContext : DbContext
{
    public GuestBookContext()
    {
    }

    public GuestBookContext(DbContextOptions<GuestBookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if (!optionsBuilder.IsConfigured)
        {
            string dir = Environment.CurrentDirectory;
            string path = string.Empty;
            path = Path.Combine(Environment.CurrentDirectory, "GuestBook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
