using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.App_Base
{
    public class BaseRequestModel
    {
        public BaseRequestHeader Header { get; set; }
         
        public BaseRequestModel()
        {
            Header = new BaseRequestHeader();
        }
    }

    public class BaseRequestHeader
    {
        public string Platform { get; set; }
    }
}
