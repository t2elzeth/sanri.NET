using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sanri.API.Authorization.API.Controllers
{
    public class UserController: ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }

        private string GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
            }
            
            return "Hello world!";
        }
    }
}