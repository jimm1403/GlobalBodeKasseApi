using GlobalBodeKasse.Core.DomainService;
using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalBodeKasse.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private GlobalDbContext _context;

        public UserRepository(GlobalDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            var newUser = _context.Users.Add(user).Entity;
            _context.SaveChangesAsync();
            return newUser;
        }

        public User DeleteUserById(int id)
        {
            var userRemoved = _context.Remove<User>(new User() { Id = id }).Entity;
            _context.SaveChanges();
            return userRemoved;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User userUpdate)
        {
            var user = _context.Users.Update(userUpdate).Entity;
            _context.SaveChangesAsync();
            return user;
        }
    }
}
