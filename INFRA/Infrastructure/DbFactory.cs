using INFRA.Entities;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Infrastructure
{
    class DbFactory : Disposable, IDbFactory
    {
        DbEntities dbContext;

        public DbEntities Init()
        {
            return dbContext ?? (dbContext = new DbContextFactory().CreateDbContext(null));
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
