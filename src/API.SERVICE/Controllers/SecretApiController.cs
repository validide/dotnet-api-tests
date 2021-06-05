using Microsoft.AspNetCore.Mvc;

namespace API.SERVICE
{
    [ApiController]
    [Route("[controller]")]
    //[ApiExplorerSettings(IgnoreApi = true)]

    public class SecretApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("OK from Secret!");
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] Secret secret)
        {
            return Ok($"OK from Secret({secret.SecretProperty})!");
        }
    }

    public class Secret
    {
        public string SecretProperty { get; set; }
    }
}
