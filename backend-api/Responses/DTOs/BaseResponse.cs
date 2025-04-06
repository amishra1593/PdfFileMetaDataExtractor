using Newtonsoft.Json;
using System.Net;

namespace FileUploaderSample.Responses.DTOs
{
    public class BaseResponse
    {
        public ErrorResponseMessage Error { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Error == null;
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode => IsSuccess ? SuccessfulStatusCode : Error.StatusCode;

        [JsonIgnore]
        public HttpStatusCode SuccessfulStatusCode { get; set; } = HttpStatusCode.OK;
    }
}
