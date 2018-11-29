using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;

namespace GlobalBodeKasse.Core.DomainService
{
    public interface IGroupSpaceRepository
    {
        GroupSpace GetGroupSpaceById(string groupSpaceId);
        IEnumerable<GroupSpace> GetAllGroupSpaces();
        GroupSpace CreateGroupSpace(GroupSpace groupSpace);
        GroupSpace DeleteGroupSpaceById(string id);
        GroupSpace UpdateGroupSpace(GroupSpace groupSpaceUpdate);
    }
}
