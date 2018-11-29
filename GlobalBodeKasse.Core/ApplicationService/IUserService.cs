using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Core.ApplicationService
{
    public interface IUserService
    {
        //New User
        User NewUser(string firstName, string lastName);

        //Create
        User CreateUser(User user);

        //read
        User FindUserById(int id);
        IEnumerable<User> GetAllUsers();

        //Update
        User UpdateUser(User userUpdate);

        //Delete
        User DeleteUserById(int id);
    }
}
