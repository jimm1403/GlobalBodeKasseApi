using GlobalBodeKasse.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace GlobalBodeKasse.Infrastructure.Data
{
    public class GlobalDbContext : DbContext
    {
        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroupSpace>()
                .HasKey(ugs => new { ugs.UserId, ugs.GroupSpaceId });

            modelBuilder.Entity<UserGroupSpace>()
                .HasOne(c => c.GroupSpace)
                .WithMany(u => u.UserGroupSpace)
                .HasForeignKey(c => c.GroupSpaceId);

            modelBuilder.Entity<UserGroupSpace>()
                .HasOne(u => u.User)
                .WithMany(x => x.UserGroupSpaces)
                .HasForeignKey(e => e.UserId);
        }


        public DbSet<GroupSpace> GroupSpaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroupSpace> UserGroupSpaces { get; set; }
    }
}
