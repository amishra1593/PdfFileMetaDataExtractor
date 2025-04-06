using Newtonsoft.Json;
using System.Net;

namespace FileUploaderSample.Responses.DTOs
{
    public class ErrorResponseMessage
    {
        [JsonIgnore]
        public virtual HttpStatusCode StatusCode { get; }
        public virtual string Message { get; }
        public virtual string Code { get; }

    }
}
