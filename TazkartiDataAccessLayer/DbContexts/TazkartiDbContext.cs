using Microsoft.EntityFrameworkCore;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DbContexts;

public class TazkartiDbContext : DbContext
{
    public TazkartiDbContext(DbContextOptions<TazkartiDbContext> options) : base(options)
    {
    }
    
    public DbSet<UserDbModel> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // make username unique
        modelBuilder.Entity<UserDbModel>()
            .HasIndex(u => u.Username)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
    
}