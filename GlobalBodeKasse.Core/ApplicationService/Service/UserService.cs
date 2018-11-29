using GlobalBodeKasse.Core.DomainService;
using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GlobalBodeKasse.Core.ApplicationService.Service
{
    public class UserService : IUserService
    { 
        readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;

        }

        public User NewUser(string firstName, string lastName)
        {
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName
            };
            return user;
        }

        public User CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                throw new InvalidDataException("Missing fields");
            }
            return _userRepo.Create(user);
        }

        public User FindUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public User UpdateUser(User userUpdate)
        {
            var user = FindUserById(userUpdate.Id);
            user.FirstName = userUpdate.FirstName;
            user.LastName = userUpdate.LastName;
            return _userRepo.Update(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User DeleteUserById(int id)
        {
            return _userRepo.DeleteUserById(id);
        }
    }
}
