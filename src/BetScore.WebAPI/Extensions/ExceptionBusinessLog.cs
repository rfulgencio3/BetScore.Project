using Newtonsoft.Json;
using System;
using System.Net;

namespace BetScore.WebAPI.Extensions
{
    public class ExceptionBusinessLog : Exception
    {
        public HttpStatusCode StatusCode;

        [JsonProperty("info_type")]
        public string InfoType = "BusinessInfo";

        public ExceptionBusinessLog() { }

        public ExceptionBusinessLog(string message, Exception innerException)
            : base(message, innerException) { }

        public ExceptionBusinessLog(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
