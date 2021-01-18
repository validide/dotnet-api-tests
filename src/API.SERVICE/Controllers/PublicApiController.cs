using Microsoft.AspNetCore.Mvc;

namespace API.SERVICE
{
    [ApiController]
    [Route("public/[controller]")]
    public class PublicApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("OK from Public!");
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] PublicMessage secret)
        {
            return Ok($"OK from Secret({secret.Value})!");
        }
    }

    // Using this causes an ERROR at runtime due to duplicate "SCHEMA".
    //public class Message
    //{
    //    public string Value { get; set; }
    //}

    public class PublicMessage
    {
        public string Value { get; set; }
    }
}
