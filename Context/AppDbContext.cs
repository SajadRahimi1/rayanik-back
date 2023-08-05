using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            entry.Property("UpdatedAt").CurrentValue = now;

            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = now;
            }
        }
        return base.SaveChanges();
    }




}