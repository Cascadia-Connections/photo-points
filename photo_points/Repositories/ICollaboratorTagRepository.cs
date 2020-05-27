using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;

namespace photo_points.Repositories
{
    public interface ICollaboratorTagRepository
    {
        IQueryable<UserTag> GetTags();
        UserTag GetTag(long tagId);
        IEnumerable<UserTag> GetAllUserTags(long id);
        void SaveChanges(UserTag userTag);
    }
}
