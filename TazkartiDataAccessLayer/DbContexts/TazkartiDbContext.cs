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
    
    public DbSet<UserDbModel> Users { get; set; }
    public DbSet<MatchDbModel> Matches { get; set; }
    public DbSet<StadiumDbModel> Stadiums { get; set; }
    public DbSet<TeamDbModel> Teams { get; set; }

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
                Id = 1,
                Username = "adhamali",
                Password = "AQAAAAEAACcQAAAAEOYxMlMfiyJz1mbgW81M0ap6FdaEYndumqz4pESkwohGdesy/P4V9yQzcKiuzdBgqA==",
                Status = UserStatus.Approved,
                Role = Role.SiteAdministrator,
            }
        );
        
        // make stadium name unique
        modelBuilder.Entity<StadiumDbModel>()
            .HasIndex(s => s.Name)
            .IsUnique();
        
        // make team name unique
        modelBuilder.Entity<TeamDbModel>()
            .HasIndex(t => t.Name)
            .IsUnique();
        
        // add 18 default teams
        modelBuilder.Entity<TeamDbModel>().HasData(
            new TeamDbModel()
            {
                Id = 1,
                Name = "Al Ahly",
            },
            new TeamDbModel()
            {
                Id = 2,
                Name = "Zamalek",
            },
            new TeamDbModel()
            {
                Id = 3,
                Name = "Al Masry",
            },
            new TeamDbModel()
            {
                Id = 4,
                Name = "Al Ittihad Al Sakandary",
            },
            new TeamDbModel()
            {
                Id = 5,
                Name = "Al Mokawloon",
            },
            new TeamDbModel()
            {
                Id = 6,
                Name = "Al Gouna",
            },
            new TeamDbModel()
            {
                Id = 7,
                Name = "Massr El Maqasah",
            },
            new TeamDbModel()
            {
                Id = 8,
                Name = "Pyramids",
            },
            new TeamDbModel()
            {
                Id = 9,
                Name = "Modern Future",
            },
            new TeamDbModel()
            {
                Id = 10,
                Name = "Ghazel Al Mahalla",
            },
            new TeamDbModel()
            {
                Id = 11,
                Name = "Baladeit Al Mahalla",
            },
            new TeamDbModel()
            {
                Id = 12,
                Name = "Farco",
            },
            new TeamDbModel()
            {
                Id = 13,
                Name = "Tanta",
            },
            new TeamDbModel()
            {
                Id = 14,
                Name = "Aswan",
            },
            new TeamDbModel()
            {
                Id = 15,
                Name = "El Sharkia",
            },
            new TeamDbModel()
            {
                Id = 16,
                Name = "El Entag El Harby",
            },
            new TeamDbModel()
            {
                Id = 17,
                Name = "Zed",
            },
            new TeamDbModel()
            {
                Id = 18,
                Name = "Saramika Celiopatra",
            }
        );
        
        
        base.OnModelCreating(modelBuilder);
    }
    
}