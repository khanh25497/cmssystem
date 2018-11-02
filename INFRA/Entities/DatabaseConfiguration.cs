using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Entities
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private readonly string ConnectionString = "DbConnectionString";
        public string GetConnectionString()
        {
            return GetConfiguration().GetConnectionString(ConnectionString);
        }
    }
}
