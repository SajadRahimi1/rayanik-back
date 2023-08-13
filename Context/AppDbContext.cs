using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(_ => _.Id);
        modelBuilder.Entity<Course>().HasKey(_ => _.Id);
        modelBuilder.Entity<Lesson>().HasKey(_ => _.Id);
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


    public DbSet<User> Users { get; set; }
    public DbSet<Course> courses { get; set; }
    public DbSet<Lesson> lessons { get; set; }

}