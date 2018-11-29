using System;
using System.Collections.Generic;

namespace GlobalBodeKasse.Core.Entity
{
    public class GroupSpace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DatabaseConnectionString { get; set; }
        public IEnumerable<UserGroupSpace> UserGroupSpace { get; set; }
    }
}
