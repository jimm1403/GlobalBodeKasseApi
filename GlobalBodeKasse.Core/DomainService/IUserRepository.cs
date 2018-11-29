using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Core.DomainService
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        User Create(User user);
        User DeleteUserById(int id);
        User Update(User userUpdate);
    }
}
