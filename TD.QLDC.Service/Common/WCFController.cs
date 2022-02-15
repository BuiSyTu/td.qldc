using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Service.Common;

namespace TD.QLDC.Service
{
    public class WCFController
    {
        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public Stream Ok(object data = null)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            var resultStream = GenerateStreamFromString(resultString);
            return resultStream;
        }

        public Stream Unauthorized(string message = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            var data = new
            {
                Message = message
            };

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            return GenerateStreamFromString(resultString);
        }

        public Stream InternalServerError(string message = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            var data = new
            {
                Message = message
            };

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            return GenerateStreamFromString(resultString);
        }

        public Stream NotFound(string message = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            var data = new
            {
                Message = message
            };

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            return GenerateStreamFromString(resultString);
        }

        public Stream BadRequest(string message = null)
        {
            var data = new
            {
                Message = message
            };

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            return GenerateStreamFromString(resultString);
        }

        public Stream Created(object data = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            var resultStream = GenerateStreamFromString(resultString);
            return resultStream;
        }

        public Stream Conflict(object data = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            var resultStream = GenerateStreamFromString(resultString);
            return resultStream;
        }

        public Stream Forbidden(object data = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Forbidden;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string resultString = JsonConvert.SerializeObject(data);
            var resultStream = GenerateStreamFromString(resultString);
            return resultStream;
        }

        public Stream ApiOk(object data = null, int total = 0, string message = null)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";

            var apiResult = new ApiResult
            {
                data = data,
                total = total,
                error = message == null
                    ? new Common.ErrorResult()
                    : new Common.ErrorResult
                    {
                        code = 200,
                        internalMessage = message,
                        userMessage = message
                    }
            };

            string resultString = JsonConvert.SerializeObject(apiResult);
            var resultStream = GenerateStreamFromString(resultString);
            return resultStream;
        }

        public Stream ApiConflict(object data = null, string message = null)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";

            var apiResult = new ApiResult
            {
                data = data,
                total = 0,
                error = message == null
                    ? new Common.ErrorResult()
                    : new Common.ErrorResult
                    {
                        code = 409,
                        internalMessage = message,
                        userMessage = message
                    }
            };

            string resultString = JsonConvert.SerializeObject(apiResult);
            var resultStream = GenerateStreamFromString(resultString);
            return resultStream;
        }
    }
}
