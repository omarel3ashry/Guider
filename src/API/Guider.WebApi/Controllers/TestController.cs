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
        public ActionResult<string> Get()
        {
            return Ok("any random string");
        }
    }
}
