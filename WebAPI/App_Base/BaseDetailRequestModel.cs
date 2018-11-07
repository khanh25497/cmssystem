using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.App_Base
{
    public class BaseDetailRequestModel<T> : BaseRequestModel where T : class
    {
        public T Record { get; set; }
    }   
}
