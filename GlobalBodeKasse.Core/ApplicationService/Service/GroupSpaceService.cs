using GlobalBodeKasse.Core.DomainService;
using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GlobalBodeKasse.Core.ApplicationService.Service
{
    public class GroupSpaceService : IGroupSpaceService
    {
        readonly IGroupSpaceRepository _groupSpaceRepo;
        readonly IUserGroupSpaceRepository _userGroupSpaceRepository;
        public GroupSpaceService(IGroupSpaceRepository groupSpaceRepo, IUserGroupSpaceRepository userGroupSpaceRepository)
        {
            _groupSpaceRepo = groupSpaceRepo;
            _userGroupSpaceRepository = userGroupSpaceRepository;

        }

        public GroupSpace NewGroupSpace(string groupSpaceId, string name, string dbConString)
        {
            GroupSpace groupSpace = new GroupSpace
            {
                Id = Guid.Parse(groupSpaceId),
                Name = name,
                DatabaseConnectionString = dbConString
            };
            return groupSpace;
;
        }
        
        //Skal lave reference til den bruger der opretter et nyt space
        public GroupSpace CreateGroupSpace(GroupSpace groupSpace, int creatorUserId)
        {
            _userGroupSpaceRepository.CreateGroupSpaceReference(groupSpace, creatorUserId);

            if (string.IsNullOrEmpty(groupSpace.Id.ToString()) || string.IsNullOrEmpty(groupSpace.Name) || string.IsNullOrEmpty(groupSpace.DatabaseConnectionString))
            {
                throw new InvalidDataException("Missing fields");
            }
            return _groupSpaceRepo.CreateGroupSpace(groupSpace);
        }

        public GroupSpace FindGroupSpaceById(string id)
        {
            return _groupSpaceRepo.GetGroupSpaceById(id);
        }

        public GroupSpace UpdateGroupSpace(GroupSpace groupSpaceUpdate)
        {
            var groupSpace = FindGroupSpaceById(groupSpaceUpdate.Id.ToString());
            groupSpace.Id = groupSpaceUpdate.Id;
            groupSpace.Name = groupSpaceUpdate.Name;
            groupSpace.DatabaseConnectionString = groupSpaceUpdate.DatabaseConnectionString;
            return _groupSpaceRepo.UpdateGroupSpace(groupSpace);
        }

        public IEnumerable<GroupSpace> GetAllGroupSpaces()
        {
            return _groupSpaceRepo.GetAllGroupSpaces();
        }

        public GroupSpace DeleteGroupSpaceById(string id)
        {
            return _groupSpaceRepo.DeleteGroupSpaceById(id);
        }
    }
}
