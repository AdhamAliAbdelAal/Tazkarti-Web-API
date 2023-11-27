﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        
        base.OnModelCreating(modelBuilder);
    }
    
}