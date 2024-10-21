using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using JobCategory = HouseCostMonitor.Domain.Entities.JobCategory;

namespace HouseCostMonitor.Infrastructure.Persistence;

internal class HouseCostMonitorDbContext : DbContext
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Invoice> Invoices { get; set; }
    internal DbSet<JobCategory> JobCategories { get; set; }
    internal DbSet<Job> Jobs { get; set; }
    internal DbSet<Report> Reports { get; set; }
    internal DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HouseCostMonitorDb;Trusted_Connection=True;");
    }
}