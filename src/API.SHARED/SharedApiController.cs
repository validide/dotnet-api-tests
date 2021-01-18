using Microsoft.AspNetCore.Mvc;

namespace API.SHARED
{
    [ApiController]
    [Route("shared/[controller]")]
    public class SharedApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("OK from Shared!");
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] Message secret)
        {
            return Ok($"OK from Secret({secret.SharedValue})!");
        }
    }

    public class Message
    {
        public string SharedValue { get; set; }
    }
}
