using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebTopicChat.BusinessLayer.Services.Auth;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var result = _authService.Login(username, password);
            if (result.Key.StatusCode == HttpStatusCode.OK)
            {
                return Ok(result.Value);
            }
            else
            {
                return Unauthorized(result.Key);
            }
        }
    }
}
