using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using photo_points.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

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

            //Captures - Will need to change database to fix this.



            //PhotoPoints
            //var features = new[] { 1, 2, 3, 4, 5, 6, 7 };
            //var testPhotos = new Faker<PhotoPoint>()
            //    .RuleFor(p => p.locationName, f => f.Address.City());
            ////.RuleFor(p => p.feature, f => f.PickRandom(features));
            //var photopoints = testPhotos.Generate(100);

            ////Add
            //await context.Users.AddRangeAsync(users);
            //await context.Captures.AddRangeAsync(captures);
            //await context.PhotoPoints.AddRangeAsync(photopoints);

            //Save
            await context.SaveChangesAsync();
        }
    }
}