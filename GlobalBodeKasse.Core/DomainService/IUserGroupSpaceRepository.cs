using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Core.DomainService
{
    public interface IUserGroupSpaceRepository
    {
        UserGroupSpace GetGroupSpacesByUserId(int userId);
        IEnumerable<UserGroupSpace> GetAllGroupSpaces();
        UserGroupSpace CreateGroupSpaceReference(GroupSpace groupSpace, int creatorUserId);
        UserGroupSpace DeleteRefereceById(string groupSpaceId, int userId);
    }
}
