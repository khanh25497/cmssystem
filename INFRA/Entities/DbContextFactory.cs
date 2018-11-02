using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Entities
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DbEntities>
    {
        private static string ConnectionString => new DatabaseConfiguration().GetConnectionString();

        public DbEntities CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DbEntities>();
            optionBuilder.UseSqlServer(ConnectionString);
            return new DbEntities(optionBuilder.Options);
        }
    }
}
