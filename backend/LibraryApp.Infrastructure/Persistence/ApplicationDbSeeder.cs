using System.Security.Cryptography;
using System.Text;
using Bogus;
using LibraryApp.Application.Common;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace LibraryApp.Infrastructure.Persistence
{
    public class ApplicationDbSeeder
    {
        public static async Task SeedCategoriesAsync(ApplicationDbContext context, ILogger<ApplicationDbSeeder> logger)
        {
            if (!context.Categories.Any())
            {
                var categoryFaker = new Faker<Category>()
                    .RuleFor(c => c.Id, f => Guid.NewGuid())
                    .RuleFor(c => c.Name, f => f.PickRandom(new[]
                    {
                    "Fiction",
                    "Non-Fiction",
                    "Science Fiction",
                    "Mystery",
                    "Romance",
                    "Biography",
                    "History",
                    "Science",
                    "Technology",
                    "Business",
                    "Self-Help",
                    "Poetry",
                    "Drama",
                    "Horror",
                    "Adventure",
                    "Fantasy",
                    "Children's Literature",
                    "Young Adult",
                    "Comics & Graphic Novels",
                    "Art & Photography"
                    }))
                    .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                    .RuleFor(c => c.CreatedAt, f => DateTime.UtcNow);

                var categories = categoryFaker.Generate(20)
                    .GroupBy(c => c.Name)
                    .Select(g => g.First())
                    .ToList();

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();

                logger.LogInformation("✅ Generated and seeded {Count} categories using Bogus.", categories.Count);
            }
            else
            {
                logger.LogInformation("Categories already exist. No seeding needed.");
            }
        }

        public static async Task SeedBooksAsync(ApplicationDbContext context, ILogger<ApplicationDbSeeder> logger)
        {
            await SeedCategoriesAsync(context, logger);

            if (!context.Books.Any())
            {
                var categoryIds = await context.Categories.Select(c => c.Id).ToListAsync();

                var bookFaker = new Faker<Book>()
                    .RuleFor(b => b.Id, f => Guid.NewGuid())
                    .RuleFor(b => b.Title, f => f.Commerce.ProductName())
                    .RuleFor(b => b.Author, f => f.Name.FullName())
                    .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                    .RuleFor(b => b.PublicationYear, f => f.Random.Int(1900, 2024))
                    .RuleFor(b => b.TotalCopies, f => f.Random.Int(5, 20))
                    .RuleFor(b => b.AvailableCopies, (f, b) => f.Random.Int(1, b.TotalCopies))
                    .RuleFor(b => b.CreatedAt, f => DateTime.UtcNow)
                    .RuleFor(b => b.CategoryId, f => f.PickRandom(categoryIds));

                var books = bookFaker.Generate(60);

                await context.Books.AddRangeAsync(books);
                await context.SaveChangesAsync();

                logger.LogInformation("✅ Generated and seeded {Count} books using Bogus.", books.Count);
            }
            else
            {
                logger.LogInformation("Books already exist. No seeding needed.");
            }
        }
        public static async Task SeedAdminUserAsync(ApplicationDbContext context, ILogger<ApplicationDbSeeder> logger, AdminAccountConfig adminConfig)
        {
            if (!context.Users.Any(u => u.UserName == adminConfig.UserName))
            {
                var adminPassword = string.IsNullOrEmpty(adminConfig.Password)
                    ? Guid.NewGuid().ToString()
                    : adminConfig.Password;

                var hashedPassword = PasswordHasher.HashPassword(adminPassword);

                var adminUser = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = adminConfig.FirstName,
                    LastName = adminConfig.LastName,
                    UserName = adminConfig.UserName,
                    Email = adminConfig.Email,
                    PhoneNumber = adminConfig.PhoneNumber,
                    Address = adminConfig.Address,
                    DateOfBirth = adminConfig.DateOfBirth,
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true,
                    PasswordHash = hashedPassword
                };

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();

                logger.LogInformation("✅ Admin user seeded. Username: {UserName}, Email: {Email}",
                    adminUser.UserName,
                    adminUser.Email);
            }
            else
            {
                logger.LogInformation("Admin user already exists. No seeding needed.");
            }
        }

    }
}
