using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Core.ApplicationService
{
    public interface IGroupSpaceService
    {
        //New GroupSpace
        GroupSpace NewGroupSpace(string groupSpaceId, string name, string dbConString);

        //Create GroupSpace and creating a new groupspace reference for a user
        GroupSpace CreateGroupSpace(GroupSpace groupSpace, int userId);

        //read
        GroupSpace FindGroupSpaceById(string id);
        IEnumerable<GroupSpace> GetAllGroupSpaces();

        //Update
        GroupSpace UpdateGroupSpace(GroupSpace groupSpaceUpdate);

        //Delete
        GroupSpace DeleteGroupSpaceById(string id);
    }
}
