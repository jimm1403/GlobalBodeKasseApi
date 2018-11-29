using GlobalBodeKasse.Core.DomainService;
using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalBodeKasse.Infrastructure.Data.Repository
{
    public class UserGroupSpaceRepository : IUserGroupSpaceRepository
    {
        private GlobalDbContext _context;

        public UserGroupSpaceRepository(GlobalDbContext context)
        {
            _context = context;
        }
        
        public UserGroupSpace CreateGroupSpaceReference(GroupSpace groupSpace, int creatorUserId)
        {
            var reference = new UserGroupSpace()
            {
                GroupSpaceId = groupSpace.Id,
                UserId = creatorUserId
            };

            var newUserGroupSpaceReference = _context.UserGroupSpaces.Add(reference).Entity;
            _context.SaveChangesAsync();
            return newUserGroupSpaceReference;
        }
        
        public UserGroupSpace DeleteRefereceById(string groupSpaceId, int userId)
        {
            var referenceRemoved = _context.Remove<UserGroupSpace>(new UserGroupSpace() { GroupSpaceId = Guid.Parse(groupSpaceId), UserId = userId }).Entity;
            _context.SaveChanges();
            return referenceRemoved;
        }
        
        public UserGroupSpace GetGroupSpacesByUserId(int userId)
        {
            return _context.UserGroupSpaces.FirstOrDefault(x => x.UserId == userId);
        }

        IEnumerable<UserGroupSpace> IUserGroupSpaceRepository.GetAllGroupSpaces()
        {
            return _context.UserGroupSpaces;
        }
    }
}
