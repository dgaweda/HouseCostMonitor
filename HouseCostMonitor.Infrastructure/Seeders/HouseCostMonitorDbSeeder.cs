using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseCostMonitor.Infrastructure.Seeders;

internal class HouseCostMonitorDbSeeder(HouseCostMonitorDbContext dbContext) : IHouseCostMonitorDbSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            // var user = GetUserSeedData();
            var expenses = GetExpenseSeedData();
            var jobs = GetJobSeedData(expenses);

            // user.Jobs = [jobs[0]];
            // user.Expenses = [expenses[0]];

            await AddIfNotExistAsync(dbContext.Expenses, expenses);
            await AddIfNotExistAsync(dbContext.Jobs, jobs);

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

    private static List<Expense> GetExpenseSeedData() =>
    [
         new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Radiator - Bathrooms 120x60",
            UnitPrice = 400,
            Quantity = 2,
            Supplier = "Allegro",
            PurchaseDate = new DateTime(2024, 09, 30),
            // UserId = null,
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
    
    private static List<Job> GetJobSeedData(IReadOnlyList<Expense> expenses)
    {
        return
        [
            new Job
            {
                Description = "Plastering",
                Duration = new TimeSpan(7, 0, 0, 0), // 7 days
                CreatedBy = "John Doe",
                JobStatus = JobStatus.InProgress,
                UserId = null,
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
    // private static User GetUserSeedData()
    // {
    //     return new User
    //     {
    //         Username = "daga",
    //         PasswordHash = "hashed_password_example",
    //         Email = "daga@example.com",
    //         Role = Role.Admin,
    //         Firstname = "Dariusz",
    //         Lastname = "Gaweda",
    //         LastLoginDate = null
    //     };
    // }
    
}