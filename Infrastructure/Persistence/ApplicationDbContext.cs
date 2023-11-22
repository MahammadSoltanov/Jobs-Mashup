using Application.Shared.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Company>()
            .HasIndex(c => c.Name)
            .IsUnique();
        modelBuilder.Entity<Company>()
            .Property(c => c.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(250);

        modelBuilder.Entity<Country>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Country>()
            .HasIndex(c => c.Name)
            .IsUnique();
        modelBuilder.Entity<Country>()
            .Property(c => c.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(60);

        modelBuilder.Entity<Job>()
            .HasKey(j => j.Id);
        modelBuilder.Entity<Job>()
            .HasIndex(j => j.JobLink)
            .IsUnique();
        modelBuilder.Entity<Job>()
            .Property(j => j.JobLink)
            .HasColumnType("varchar")
            .HasMaxLength(2048);
        modelBuilder.Entity<Job>()
            .Property(j => j.Position)
            .HasColumnType("nvarchar")
            .HasMaxLength(250);
        //Relationships with other tables
        modelBuilder.Entity<Job>()
            .HasOne(j => j.Country)
            .WithMany(c => c.Jobs)
            .HasForeignKey(j => j.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.Company)
            .WithMany(c => c.Jobs)
            .HasForeignKey(j => j.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Country> Countries{ get; set; }
}
