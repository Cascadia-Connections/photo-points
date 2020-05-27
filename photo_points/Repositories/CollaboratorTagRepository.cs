using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using photo_points.Models;
using photo_points.Services;


namespace photo_points.Repositories
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project



    public class CollaboratorTagRepository : ICollaboratorTagRepository
    {
        
        
        public List<UserTag> userTags = new List<UserTag> {
                new UserTag {
                    userID = 2,
                    tagID = 1
                    },
                new UserTag {
                    userID = 2,
                    tagID = 1
                    },
                new UserTag {
                    userID = 3,
                    tagID = 1
                    },
                new UserTag {
                    userID = 3,
                    tagID = 2
                    },
                new UserTag {
                    userID = 1,
                    tagID = 2
                    } } ;

    

        public IQueryable<UserTag> tags => userTags.AsQueryable<UserTag>();

        public IQueryable<UserTag> GetTags()
        {
            return tags;
        }

        public UserTag GetTag(long id)
        {
            return tags.SingleOrDefault(r => r.tagID == id);
        }

        public IEnumerable<UserTag> GetAllUserTags(long id)
        {
            return tags.Where(a => a.userID == id); 
        }

        public void SaveChanges(UserTag ut)
        {
            foreach (photo_points.Models.UserTag t in userTags)
            {
                if (t.tagID == ut.tagID)

                {
                    t.User = ut.User;
                    t.userID = ut.userID;
                    t.Tag = ut.Tag;
                    t.tagID = ut.tagID;
                }
            }
            return;
        }
    }
}