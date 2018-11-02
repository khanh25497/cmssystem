using CORE.Models;
using INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFRA.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<User> GetAll(string username)
        {
            var users = from user in this.DbContext.Users
                        where user.Username.Contains(username)
                        select user;
            return users;
        }

        public User Login(string username, string password)
        {
            var user = this.DbContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            this.DbContext.Entry(user).Reference(u => u.Role).Load();
            this.DbContext.Entry(user).Reference(u => u.School).Load();
            return user;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string password);
        IEnumerable<User> GetAll(string username);
    }
}
