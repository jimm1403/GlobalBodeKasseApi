using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Core.Entity
{
    public class UserGroupSpace
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Guid GroupSpaceId { get; set; }
        public GroupSpace GroupSpace { get; set; }
    }
}
