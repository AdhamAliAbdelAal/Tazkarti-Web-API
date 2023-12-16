using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DbContexts;

public class TazkartiDbContext : DbContext
{
    public IConfiguration _configuration { get; }
    public TazkartiDbContext(DbContextOptions<TazkartiDbContext> options,IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    public DbSet<UserDbModel> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(this._configuration["ConnectionStrings:TazkartiDbContextConnection"] ?? string.Empty);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // make username unique
        modelBuilder.Entity<UserDbModel>()
            .HasIndex(u => u.Username)
            .IsUnique();
        
        // add default data
        modelBuilder.Entity<UserDbModel>().HasData(
            new UserDbModel()
            {
                Id = 2,
                Username = "adhamali",
                Password = "AQAAAAEAACcQAAAAEOYxMlMfiyJz1mbgW81M0ap6FdaEYndumqz4pESkwohGdesy/P4V9yQzcKiuzdBgqA==",
                Status = UserStatus.Approved,
                Role = Role.SiteAdministrator,
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }
    
}