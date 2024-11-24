using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseCostMonitor.Infrastructure.Seeders;

using System.Collections;
using HouseCostMonitor.Domain.Constants;

internal class HouseCostMonitorDbSeeder(HouseCostMonitorDbContext dbContext) : IHouseCostMonitorDbSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            var expenses = GetExpenses();
            var jobs = GetJobs(expenses);
            var roles = GetRoles();
            var houses = GetHouses(jobs);
            
            await AddIfNotExistAsync(dbContext.Expenses, expenses);
            await AddIfNotExistAsync(dbContext.Jobs, jobs);
            await AddIfNotExistAsync(dbContext.Roles, roles);
            await AddIfNotExistAsync(dbContext.Houses, houses);

            await dbContext.SaveChangesAsync();
        }
    }

    private async Task AddIfNotExistAsync<T>(DbSet<T> dbSet, IEnumerable<T> entities) where T : class
    {
        if (!dbSet.Any())
        {
            await dbSet.AddRangeAsync(entities);
        }
    }

    private static List<Expense> GetExpenses() =>
    [
         new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Radiator - Bathrooms 120x60",
            UnitPrice = 400,
            Quantity = 2,
            Supplier = "Allegro",
            PurchaseDate = new DateTime(2024, 09, 30),
            JobId = null,
        },
        new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Gypsum - Bag",
            UnitPrice = 80m,
            Quantity = 10,
            Supplier = "BricoMarche",
            PurchaseDate = new DateTime(2024, 10, 03),
            JobId = null,
        },
        new Expense
        {
            Type = ExpenseType.Tools,
            Description = "Gypsum tools",
            UnitPrice = 120m,
            Quantity = 2,
            Supplier = "Allegro",
            PurchaseDate = new DateTime(2024, 10, 08),
            JobId = null,
        },
        new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Floor panels - 1 package 1.5m",
            UnitPrice = 150m,
            Quantity = 75,
            Supplier = "BricoMarche",
            PurchaseDate = new DateTime(2024, 10, 14),
            JobId = null,
        },
        new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Tiles - 60x60 - 1pkg - 5m2",
            UnitPrice = 130m,
            Quantity = 10,
            Supplier = "KOMFORT",
            PurchaseDate = new DateTime(2024, 10, 19),
            JobId = null,
        },
        new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Paint - 20l",
            UnitPrice = 50m,
            Quantity = 10,
            Supplier = "MROWKA",
            PurchaseDate = new DateTime(2024, 10, 19),
            JobId = null,
        }
    ];
    
    private static List<Job> GetJobs(IReadOnlyList<Expense> expenses)
    {
        return
        [
            new Job
            {
                Description = "Plastering",
                Duration = new TimeSpan(7, 0, 0, 0), // 7 days
                CreatedBy = "John Doe",
                JobStatus = JobStatus.InProgress,
                Expenses =
                [
                    expenses[1],
                    expenses[2]
                ]
            },

            new Job
            {
                Description = "Tiling",
                Duration = new TimeSpan(9, 0, 0, 0), // 9 days
                CreatedBy = "Jane Smith",
                JobStatus = JobStatus.Done,
                Expenses =
                [
                    expenses[3],
                    expenses[4]
                ]
            },

            new Job
            {
                Description = "Painting",
                Duration = new TimeSpan(2, 0, 0, 0), // 2 days
                CreatedBy = "Mike Johnson",
                JobStatus = JobStatus.Pending,
                Expenses =
                [
                    expenses[5]
                ]
            }
        ];
    }

    private static IEnumerable<Role> GetRoles()
    {
        var adminRoleId = Guid.Parse("c58709f6-3997-4987-9dbf-a83a72c82809");
        var ownerRoleId = Guid.Parse("21e54bee-47d9-415e-b09c-1db273583cef");
        var userRoleId = Guid.Parse("4a3af547-6cc6-4ec0-803b-438ea0af1487");
        
        return [
            new Role
            {
                Id = adminRoleId,
                Name = Roles.Admin,
                RoleType = RoleType.Admin,
                NormalizedName = Roles.Admin
            },
            new Role
            {
                Id = ownerRoleId,
                Name = Roles.User,
                RoleType = RoleType.Owner,
                NormalizedName = Roles.Owner
            },
            new Role
            {
                Id = userRoleId,
                Name = Roles.User,
                RoleType = RoleType.User,
                NormalizedName = Roles.User
            }
        ];
    }

    private static IEnumerable<House> GetHouses(IEnumerable<Job> jobs)
    {
        return
        [
            new House
            {
                Name = "My House",
                HouseSquareFootage = 100,
                Jobs = [
                    jobs.First()
                ]
            }
        ];
    }
    
}