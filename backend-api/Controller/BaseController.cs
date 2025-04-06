using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FileUploaderSample.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        protected ObjectResult getActionResultObject(HttpStatusCode code, object response)
        {
            return StatusCode((int)code, response);
        }
    }
}
