using INFRA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DbEntities Init();
    }
}
