using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace HouseCostMonitor.Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

internal class HouseCostMonitorDbContext(DbContextOptions<HouseCostMonitorDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    internal DbSet<House> Houses { get; set; }
    internal DbSet<Job> Jobs { get; set; }
    internal DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>()
            .HasOne(job => job.House)
            .WithMany(house => house.Jobs)
            .HasForeignKey(job => job.HouseId);
        
        modelBuilder.Entity<Expense>()
            .HasOne(expense => expense.Job)
            .WithMany(job => job.Expenses)
            .HasForeignKey(expense => expense.JobId);
        
        modelBuilder.Entity<Expense>()
            .Property(expense => expense.UnitPrice)
            .HasPrecision(25, 2);
        
        modelBuilder.Entity<Expense>()
            .Property(expense => expense.TotalCost)
            .HasPrecision(25, 2);

        modelBuilder.Entity<Job>()
            .HasOne(job => job.User)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.UserId);

        modelBuilder.Entity<User>()
            .HasOne(user => user.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(user => user.RoleId);

        modelBuilder.Entity<House>()
            .Property(house => house.HouseSquareFootage)
            .HasPrecision(25, 2);

        modelBuilder.Entity<House>()
            .HasOne(house => house.Owner)
            .WithMany(owner => owner.Houses)
            .HasForeignKey(house => house.OwnerId);
    }

    public override int SaveChanges()
    {
        UpdateTimeStamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimeStamps()
    {
        var entities = ChangeTracker.Entries<BaseEntity>();
        foreach (var entityEntry in entities)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entityEntry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }
    }
}