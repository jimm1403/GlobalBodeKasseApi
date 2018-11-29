using GlobalBodeKasse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalBodeKasse.Infrastructure.Data
{
    public class DatabaseTestSeeder
    {
        public static void SeedGlobalDb(GlobalDbContext context)
        {
            //context.Database.EnsureDeleted(); // only in devMODE ! ! ! 
            context.Database.EnsureCreated();

            #region GroupSpaces
            //var kaffeklub = context.GroupSpaces.Add(new GroupSpace
            //{
            //    Id = Guid.Parse("79865406-e01b-422f-bd09-92e116a0664a"),
            //    DatabaseConnectionString = "Data Source=kaffeklub.db",
            //    Name = "kaffeklub"
            //});
            //var otteruphk = context.GroupSpaces.Add(new GroupSpace
            //{
            //    Id = Guid.Parse("79605406-e01b-424f-bd08-92e117a0664a"),
            //    DatabaseConnectionString = "Data Source=otteruphk.db",
            //    Name = "otteruphk"
            //});
            #endregion

            #region Users
            //var user1 = context.Users.Add(new User()
            //{
            //    FirstName = "Jimmi",
            //    LastName = "Christensen",
            //});
            //var user2 = context.Users.Add(new User()
            //{
            //    FirstName = "Jens",
            //    LastName = "Dideriksen",
            //});
            //var user3 = context.Users.Add(new User()
            //{
            //    FirstName = "Jesper",
            //    LastName = "Andersen",
            //});
            //var user4 = context.Users.Add(new User()
            //{
            //    FirstName = "Mikkel",
            //    LastName = "Vedel",
            //});
            //var user5 = context.Users.Add(new User()
            //{
            //    FirstName = "Morten",
            //    LastName = "Munck",
            //});
            #endregion

            #region UserGroupSpaceReferences
            //var ref1 = new UserGroupSpace { GroupSpace = kaffeklub.Entity, User = user1.Entity };
            //var ref2 = new UserGroupSpace { GroupSpace = kaffeklub.Entity, User = user2.Entity };
            //var ref3 = new UserGroupSpace { GroupSpace = kaffeklub.Entity, User = user3.Entity };
            //var ref4 = new UserGroupSpace { GroupSpace = otteruphk.Entity, User = user4.Entity };
            //var ref5 = new UserGroupSpace { GroupSpace = otteruphk.Entity, User = user5.Entity };

            //var ref6 = new UserGroupSpace { GroupSpace = otteruphk.Entity, User = user1.Entity };
            //var ref7 = new UserGroupSpace { GroupSpace = otteruphk.Entity, User = user2.Entity };
            #endregion

            //context.UserGroupSpaces.AddRange(ref1, ref2, ref3, ref4, ref5, ref6, ref7);
            
            context.SaveChanges();
        }
    }
}
