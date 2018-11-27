using CORE.Models;
using INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFRA.Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Role GetByName(string name)
        {
            return this.DbContext.Roles.Where(r => r.Name == name).FirstOrDefault();
        }
    }
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string name);
    }
}
