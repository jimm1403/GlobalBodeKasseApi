using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<UserGroupSpace> UserGroupSpaces { get; set; }

    }
}
