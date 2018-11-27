using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.App_Base;

namespace WebAPI.App_Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;

            var result = new BaseResponseModel
            {
                Header = new ResponseHeader
                {
                    ResultCode = "4953",
                    Message = "A system error has occurred"
                }
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                Formatting = Formatting.Indented
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(result, settings));
        }
    }
}
