using Microsoft.AspNetCore.Authorization;
using Guider.Identity.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TestController : ControllerBase
    {
        private readonly JwtFactory _jwtFactory;

        public TestController(JwtFactory jwtFactory)
        {
            _jwtFactory = jwtFactory;
        }

        [HttpGet("test", Name = "GetAnyRandomString")]
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

        [HttpGet("getkey", Name = "GetDummyKey")]
        public ActionResult GetDummyKey(int userId, string email, string roleTitle)
        {
            var key = _jwtFactory.GenerateJwt(userId, email, roleTitle);
            return Ok(new { key });
        }
    }
}
