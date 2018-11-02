using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
