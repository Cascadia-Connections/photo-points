using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using photo_points.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace photo_points
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await Seed(services.GetRequiredService<PhotoDataContext>());
        }

        public static async Task Seed(PhotoDataContext context)
        {
            if (context.Users.Any())
            {
                return; //already has data, don't add any more test data
            }

            //  NuGet Package "Bogus" fake data generator
            Randomizer.Seed = new Random(8672042);

            //Users
            var testUsers = new Faker<User>()
                .RuleFor(u => u.firstName, f => f.Name.FirstName())
                .RuleFor(u => u.lastName, f => f.Name.LastName())
                .RuleFor(u => u.email, (f, u) => f.Internet.Email(u.firstName, u.lastName))
                .RuleFor(u => u.password, f => f.Internet.Password(8, true));
            var users = testUsers.Generate(100);

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}