using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebTopicChat.Domain.DTOs.Request.Auth;
using WebTopicChat.Infrastructure.Services.Auth;

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
        public IActionResult Login(LoginRequestModel model)
        {
            var result = _authService.Login(model.UserName, model.Password);
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
