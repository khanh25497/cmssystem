
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.App_Base
{
    public class BaseResponseModel : BaseDeleteModel
    {
        public ResponseHeader Header { get; set; }
        public JObject Records { get; set; }
        public JObject RecordList { get; set; }
        public JsonSerializer serializer { get; set; }
        public BaseResponseModel()
        {
            Header = new ResponseHeader
            {
                ResultCode = "1000",
                Message = "System processing is complete"
            };
            Records = new JObject() as dynamic;
            RecordList = new JObject() as dynamic;
            serializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public void AddRecord(string property, object record)
        {
            if(record != null)
            {
                this.Records.Add(property, JToken.FromObject(record, serializer));
            }
        }

        public void AddRecordList(string property, object recordList)
        {
            if(recordList != null)
            {
                this.RecordList.Add(property, JToken.FromObject(recordList, serializer));
            }
        }

        public void AddError(object record)
        {
            if (record != null)
            {
                this.RecordList.Add("errors", JToken.FromObject(record, serializer));
            }
        }
    }
    public class ResponseHeader
    {
        public string ResultCode { get; set; }
        public string Message { get; set; }
    }
}
