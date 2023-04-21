using Microsoft.EntityFrameworkCore;

namespace GuestBook.EntityModels;

public partial class GuestBookContext : DbContext
{
    public GuestBookContext(DbContextOptions<GuestBookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CEE4F815D8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
