using CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Entities
{
    public class DbEntitiesSeed
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, RoleId = 1, Username = "admin", Password = "admin", SchoolId = 1 },
                new User() { Id = 2, RoleId = 2, Username = "manager", Password = "manager", SchoolId = 2 },
                new User() { Id = 3, RoleId = 3, Username = "teacher", Password = "teacher", SchoolId = 3 },
                new User() { Id = 4, RoleId = 4, Username = "parent", Password = "parent", SchoolId = 1 }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Administrator" },
                new Role() { Id = 2, Name = "Manager" },
                new Role() { Id = 3, Name = "Teacher" },
                new Role() { Id = 4, Name = "Parent" }
            );

            modelBuilder.Entity<School>().HasData(
                new School() { Id = 1, Name = "School 1"},
                new School() { Id = 2, Name = "School 2"},
                new School() { Id = 3, Name = "School 3"}
                );
        }
    }
}
