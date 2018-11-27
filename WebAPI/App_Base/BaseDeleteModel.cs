using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.App_Base
{
    public class BaseDeleteModel
    {
        public DeleteResponse Action { get; set; }
        public BaseDeleteModel()
        {
            Action = new DeleteResponse
            {
                Result = "OK",
                Message = "YOLO"
            };
        }
    }

    public class DeleteResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
    }
}
