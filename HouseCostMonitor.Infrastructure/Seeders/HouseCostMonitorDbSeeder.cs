using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Infrastructure.Persistence;

namespace HouseCostMonitor.Infrastructure.Seeders;

internal class HouseCostMonitorDbSeeder(HouseCostMonitorDbContext dbContext)
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            var expenses = GetExpenseSeedData();
            var jobs = GetJobSeedData(expenses);
            
            if (!dbContext.Expenses.Any())
            {
                await dbContext.Expenses.AddRangeAsync(expenses);
            }

            if (!dbContext.Invoices.Any())
            {
                await dbContext.Invoices.AddRangeAsync(GetInvoiceSeedData(expenses));
            }

            if (!dbContext.Jobs.Any())
            {
                await dbContext.Jobs.AddRangeAsync(GetJobSeedData(expenses));
            }

            if (!dbContext.Users.Any())
            {
                await dbContext.Users.AddAsync(GetUserSeedData(jobs, expenses));
            }

            await dbContext.SaveChangesAsync();
        }
    }

    private static List<Expense> GetExpenseSeedData() =>
    [
         new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Cement bags for foundation",
            DateIncurred = new DateTime(2024, 10, 01),
            UnitPrice = 8.50m,
            Quantity = 100,
            TotalCost = 850m,
            Supplier = "Construction Supplies Ltd.",
            PurchaseDate = new DateTime(2024, 09, 30),
            UserId = Guid.NewGuid(),
            JobId = null,
            InvoiceId = null
        },
        new Expense
        {
            Type = ExpenseType.Labor,
            Description = "Plumbing services",
            DateIncurred = new DateTime(2024, 10, 05),
            UnitPrice = 25m,
            Quantity = 8,
            TotalCost = 200m,
            Supplier = "QuickFix Plumbing",
            PurchaseDate = new DateTime(2024, 10, 03),
            UserId = Guid.NewGuid(),
            JobId = null,
            InvoiceId = null
        },
        new Expense
        {
            Type = ExpenseType.Tools,
            Description = "Rental of cement mixer",
            DateIncurred = new DateTime(2024, 10, 10),
            UnitPrice = 45m,
            Quantity = 3,
            TotalCost = 135m,
            Supplier = "Equipment Rentals Inc.",
            PurchaseDate = new DateTime(2024, 10, 08),
            UserId = Guid.NewGuid(),
            JobId = Guid.NewGuid(),
            InvoiceId = null
        },
        new Expense
        {
            Type = ExpenseType.Materials,
            Description = "Steel rods",
            DateIncurred = new DateTime(2024, 10, 15),
            UnitPrice = 12m,
            Quantity = 50,
            TotalCost = 600m,
            Supplier = "SteelWorks Co.",
            PurchaseDate = new DateTime(2024, 10, 14),
            UserId = Guid.NewGuid(),
            JobId = null,
            InvoiceId = null
        },
        new Expense
        {
            Type = ExpenseType.Labor,
            Description = "Electrician services",
            DateIncurred = new DateTime(2024, 10, 20),
            UnitPrice = 30m,
            Quantity = 10,
            TotalCost = 300m,
            Supplier = "PowerFix Electric",
            PurchaseDate = new DateTime(2024, 10, 19),
            UserId = Guid.NewGuid(),
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
                TotalCost = 850m,
                IssuedDate = new DateTime(2024, 10, 02),
                DueDate = new DateTime(2024, 10, 20),
                InvoiceStatus = InvoiceStatus.Paid,
                DocumentUrl = "https://example.com/invoice1.pdf",
                Expenses = [expenses[0]]
            },
            new()
            {
                TotalCost = 800m,
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
                TotalCost = 900m,
                IssuedDate = new DateTime(2024, 10, 16),
                DueDate = new DateTime(2024, 11, 05),
                InvoiceStatus = InvoiceStatus.Pending,
                DocumentUrl = "https://example.com/invoice3.pdf",
                Expenses = [expenses[3]]
            }
        };
    }
    private static List<Job> GetJobSeedData(IReadOnlyList<Expense> expenses)
    {
        return
        [
            new Job
            {
                Description = "Foundation work",
                EstimatedTime = new TimeSpan(40, 0, 0), // 40 hours
                CreatedBy = "John Doe",
                JobStatus = JobStatus.InProgress,
                UserId = expenses[0].UserId, // Assuming first expense has associated UserId
                Expenses =
                [
                    expenses[0] // Cement bags expense
                ]
            },

            new Job
            {
                Description = "Plumbing installation",
                EstimatedTime = new TimeSpan(24, 0, 0), // 24 hours
                CreatedBy = "Jane Smith",
                JobStatus = JobStatus.Done,
                UserId = expenses[1].UserId, // Matching the UserId for plumbing service
                Expenses = new List<Expense>
                {
                    expenses[1], // Plumbing services
                }
            },

            new Job
            {
                Description = "Electrical wiring",
                EstimatedTime = new TimeSpan(30, 0, 0), // 30 hours
                CreatedBy = "Mike Johnson",
                JobStatus = JobStatus.Pending,
                UserId = expenses[4].UserId, // Electrician service
                Expenses = new List<Expense>
                {
                    expenses[4], // Electrician services
                }
            }
        ];
    }
    private static User GetUserSeedData(List<Job> jobs, List<Expense> expenses)
    {
        return new User
        {
            Username = "daga",
            PasswordHash = "hashed_password_example", // Replace with a real hashed password
            Email = "johndoe@example.com",
            Role = Role.Admin,
            Fullname = "Dariusz Gawęda",
            LastLoginDate = null,
            Jobs = jobs,
            Expenses = expenses
        };
    }
    
}