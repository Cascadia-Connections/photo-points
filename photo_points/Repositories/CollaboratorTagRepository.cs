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
        public List<Tag> repo = new List<Tag> {
                new Tag {

                    },
                new Tag {

                 },

                new Tag {
                 }
        };

        public IQueryable<Tag> tags => repo.AsQueryable<Tag>();

        public IQueryable<Tag> GetTags()
        {
            return tags;
        }

        public Tag GetTag(long id)
        {
            return tags.SingleOrDefault(r => r.tagID == id);
        }

        public IEnumerable<Tag> GetAllUserTags(long id)
        {
            // return tags.Where(a => a.user == true);
            return tags.Where(a => a.user.userID == id); // Approve//Pening//or Reject to test 

        }

        public void SaveChanges(Tag tg)
        {
            foreach (photo_points.Models.Tag t in repo)
            {
                //it will compare properties in fake repository with service changes
                //it will save and replace new info to repo
                if (t.tagID == tg.tagID)

                {
                    t.capture = tg.capture;
                    t.tagName = tg.tagName;
                    t.user = tg.user;
                    t.Users = tg.Users;
                }

            }




        }
    }
}