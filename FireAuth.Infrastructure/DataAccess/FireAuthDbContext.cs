using System;
using FireAuth.Domain.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FireAuth.Infrastructure.DataAccess;

public class FireAuthDbContext : DbContext
{
    public FireAuthDbContext(DbContextOptions<FireAuthDbContext> options) :base(options)
    {
        
    }
    public DbSet<ApplicationUser> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserRole>().HasKey(ur => new{ur.UserId});
        modelBuilder.Entity<UserRole>()
        .HasOne(ur=> ur.User)
        .WithMany(u=> u.UserRoles)
        .HasForeignKey(ur=> ur.UserId);

        modelBuilder.Entity<UserRole>()
        .HasOne(ur=> ur.Role)
        .WithMany(r=> r.UserRoles)
        .HasForeignKey(ur=>ur.RoleId);
    }
}
