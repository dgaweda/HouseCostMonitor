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
            var user = GetUserSeedData();
            var expenses = GetExpenseSeedData(user);
            var jobs = GetJobSeedData(expenses, user);
            var invoices = GetInvoiceSeedData(expenses);

            user.Jobs = [jobs[0]];
            user.Expenses = [expenses[0]];

            await AddIfNotExistAsync(dbContext.Expenses, expenses);
            await AddIfNotExistAsync(dbContext.Invoices, invoices);
            await AddIfNotExistAsync(dbContext.Jobs, jobs);
            await AddIfNotExistAsync(dbContext.Users, [user]);

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

    private static List<Expense> GetExpenseSeedData(User user) =>
    [
         new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Radiator - Bathrooms 120x60",
            UnitPrice = 400,
            Quantity = 2,
            Supplier = "Allegro",
            PurchaseDate = new DateTime(2024, 09, 30),
            UserId = user.Id,
            JobId = null,
            InvoiceId = null
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
            InvoiceId = null
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
            InvoiceId = null
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
            InvoiceId = null
        },
        new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Tiles - 60x60 - 1pkg - 5m2",
            UnitPrice = 130m,
            Quantity = 10,
            Supplier = "PowerFix Electric",
            PurchaseDate = new DateTime(2024, 10, 19),
            JobId = null,
            InvoiceId = null
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
            InvoiceId = null
        }
    ];
    private static IEnumerable<Invoice> GetInvoiceSeedData(IReadOnlyList<Expense> expenses)
    {
        return new List<Invoice>
        {
            new()
            {
                IssuedDate = new DateTime(2024, 10, 02),
                DueDate = new DateTime(2024, 10, 20),
                InvoiceStatus = InvoiceStatus.Paid,
                DocumentUrl = "https://example.com/invoice1.pdf",
                Expenses = [expenses[0]]
            },
            new()
            {
                IssuedDate = new DateTime(2024, 10, 06),
                DueDate = new DateTime(2024, 10, 25),
                InvoiceStatus = InvoiceStatus.Pending,
                DocumentUrl = "https://example.com/invoice2.pdf",
                Expenses =
                [
                    expenses[1], // Plumbing services expense
                    expenses[2]
                ]
            },
            new()
            {
                IssuedDate = new DateTime(2024, 10, 16),
                DueDate = new DateTime(2024, 11, 05),
                InvoiceStatus = InvoiceStatus.Pending,
                DocumentUrl = "https://example.com/invoice3.pdf",
                Expenses = [expenses[3]]
            }
        };
    }
    private static List<Job> GetJobSeedData(IReadOnlyList<Expense> expenses, User user)
    {
        return
        [
            new Job
            {
                Description = "Plastering",
                EstimatedTime = new TimeSpan(40, 0, 0), // 40 hours
                CreatedBy = "John Doe",
                JobStatus = JobStatus.InProgress,
                UserId = user.Id,
                Expenses =
                [
                    expenses[1],
                    expenses[2]
                ]
            },

            new Job
            {
                Description = "Tiling",
                EstimatedTime = new TimeSpan(24, 0, 0), // 24 hours
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
                EstimatedTime = new TimeSpan(30, 0, 0), // 30 hours
                CreatedBy = "Mike Johnson",
                JobStatus = JobStatus.Pending,
                Expenses =
                [
                    expenses[5]
                ]
            }
        ];
    }
    private static User GetUserSeedData()
    {
        return new User
        {
            Username = "daga",
            PasswordHash = "hashed_password_example",
            Email = "daga@example.com",
            Role = Role.Admin,
            Fullname = "Dariusz Gaweda",
            LastLoginDate = null
        };
    }
    
}