using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestController : ControllerBase
    {

        [HttpGet("test", Name = "GetAnyRandomString")]
        [Authorize]
        public ActionResult<string> Get()
        {
            var roles = HttpContext.User.FindAll(ClaimTypes.Role).ToList().Select(e => e.Value);
            return Ok($"your role is {string.Join(",", roles)}");
        }

        [HttpGet("adminTest", Name = "GetAnyRandomStringforAdminTest")]
        [Authorize(Roles = "Admin")]
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

        //[HttpGet("getkey", Name = "GetDummyKey")]
        //public ActionResult GetDummyKey(int userId, string email, string roleTitle)
        //{
        //    var key = _jwtFactory.GenerateToken(userId, email, roleTitle);
        //    return Ok(new { key });
        //}
    }
}
