using GlobalBodeKasse.Core.DomainService;
using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalBodeKasse.Infrastructure.Data.Repository
{
    public class GroupSpaceRepository : IGroupSpaceRepository
    {
        private GlobalDbContext _context;

        public GroupSpaceRepository(GlobalDbContext context)
        {
            _context = context;
        }
        public GroupSpace CreateGroupSpace(GroupSpace groupSpace)
        {
            var newGroupSpace = _context.GroupSpaces.Add(groupSpace).Entity;
            _context.SaveChangesAsync();
            return newGroupSpace;
        }

        public GroupSpace DeleteGroupSpaceById(string id)
        {
            var groupSpaceRemoved = _context.Remove<GroupSpace>(new GroupSpace() { Id = Guid.Parse(id) }).Entity;
            _context.SaveChanges();
            return groupSpaceRemoved;
        }

        public IEnumerable<GroupSpace> GetAllGroupSpaces()
        {
            return _context.GroupSpaces;
        }

        public GroupSpace GetGroupSpaceById(string groupSpaceId)
        {
            return _context.GroupSpaces.FirstOrDefault(x => x.Id == Guid.Parse(groupSpaceId));
        }

        public GroupSpace UpdateGroupSpace(GroupSpace groupSpaceUpdate)
        {
            var groupSpace = _context.GroupSpaces.Update(groupSpaceUpdate).Entity;
            _context.SaveChangesAsync();
            return groupSpace;
        }
    }
}
