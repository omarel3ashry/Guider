using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TestController : ControllerBase
    {
        public TestController()
        {

        }

        [HttpGet(Name = "GetAnyRandomString")]
        //[Authorize]
        public ActionResult<string> Get()
        {
            return Ok("any random string");
        }

        [HttpGet("adminTest",Name = "GetAnyRandomStringforAdminTest")]
        [Authorize(Roles ="Admin")]
        public ActionResult<string> Get2()
        {
            return Ok("any random string for admin role test");
        }

        [HttpGet("clientTest", Name = "GetAnyRandomStringForClientTest")]
        [Authorize(Roles = "Client")]
        public ActionResult<string> Get3()
        {
            return Ok("any random string for client role test");
        }
    }
}
