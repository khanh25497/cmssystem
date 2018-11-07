using CORE.Models;
using INFRA.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
            var users = this.DbContext.Users.Where(u => u.Username == username)
                .Include(u => u.Role)
                .Include(u => u.School);
            return users;
        }

        public User Login(string username, string password)
        {
            var user = this.DbContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            this.DbContext.Entry(user).Reference(u => u.Role).Load();
            this.DbContext.Entry(user).Reference(u => u.School).Load();
            return user;
        }

        public override IEnumerable<User> GetAll()
        {
            var users = this.DbContext.Users
                .Include(u => u.Role)
                .Include(u => u.School);
            return users;
        }

        public override User GetById(int id)
        {
            var user = this.DbContext.Users.Where(u => u.Id == id)
                .Include(u => u.Role)
                .Include(u => u.School).FirstOrDefault();
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = this.DbContext.Users.Where(u => u.Username == username)
                .Include(u => u.Role)
                .Include(u => u.School).FirstOrDefault();
            return user;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string password);
        IEnumerable<User> GetAll(string username);
        User GetByUsername(string username);
    }
}
