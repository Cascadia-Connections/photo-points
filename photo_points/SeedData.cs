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

            byte[] imgdata = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg");

            byte[] imgdata1 = System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg");

            byte[] imgdata2 = System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg");

            var captures = new List<Capture> {
                new Capture
                {
                    photo = imgdata,
                    captureDate = DateTime.Now,
                    approval=Capture.ApprovalType.Pending,
                    photoPoint=
                    CreatePhotoPoint(PhotoPoint.FeatureType.Leaves, "Oak Trees #1"),
                    user=
                    CreateUser("Tom", "Jones", "TomJones@gmail.com", "password"),
                    tags=new List<Tag>
                    {
                        CreateTag("Leaves Falling"),
                        CreateTag("On Track")
                    },
                    data=new List<Data>
                    {
                       CreateData("Color", "Green"),
                       CreateData("Color", "Red"),
                    }
                } 
            };

        var users = CreateUser("John", "Jones", "jonjones@gmail.com", "password");

        await context.Users.AddAsync(users);
        await context.Captures.AddRangeAsync(captures);
            
            await context.SaveChangesAsync();
        }
        public static Data CreateData(string type, string value)
        {
            Data newData = new Data();
            newData.type = type;
            newData.value = value;
            return newData;
        }

        public static User CreateUser(string firstName, string lastName, string email, string password)
        {
            User user = new User
            {
                firstName = firstName,
                lastName = lastName,
                email = email,
                password= password
            };

            return user;
        }
        
        public static Tag CreateTag(string tagName)
        {
            Tag tag = new Tag
            {
                tagName = tagName
            };

            return tag;
        }
        public static PhotoPoint CreatePhotoPoint(PhotoPoint.FeatureType feature, string locationName)
        {
            PhotoPoint photoPoint = new PhotoPoint
            {
                feature = feature,
                locationName = locationName
            };

            return photoPoint;
        }

    }
}