﻿using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HouseCostMonitor.Infrastructure.Persistence;

internal class HouseCostMonitorDbContext(DbContextOptions<HouseCostMonitorDbContext> options) : DbContext(options)
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Invoice> Invoices { get; set; }
    internal DbSet<Job> Jobs { get; set; }
    internal DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(user => user.Jobs)
            .WithOne()
            .HasForeignKey(job => job.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(user => user.Expenses)
            .WithOne()
            .HasForeignKey(expense => expense.UserId);

        modelBuilder.Entity<Job>()
            .HasMany(job => job.Expenses)
            .WithOne()
            .HasForeignKey(expense => expense.JobId);

        modelBuilder.Entity<Invoice>()
            .HasMany(invoice => invoice.Expenses)
            .WithOne()
            .HasForeignKey(expense => expense.InvoiceId);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.TotalCost)
            .HasPrecision(25, 2);

        modelBuilder.Entity<Expense>()
            .Property(expense => expense.UnitPrice)
            .HasPrecision(25, 2);
        
        modelBuilder.Entity<Expense>()
            .Property(expense => expense.TotalCost)
            .HasPrecision(25, 2);
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