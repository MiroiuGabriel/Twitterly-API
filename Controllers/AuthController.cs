using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Twitterly_API.Dtos;
using Twitterly_API.Services;

namespace Twitterly_API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Signup(UserSignupDto request)
        {
            if (await _userService.IsExistingUserAsync(request.Username)) return Conflict("There already is an account for the given credentials");
            if (request.Password != request.ConfirmPassword) return Unauthorized("Passwords do not match");
            string hash = _authService.HashPassword(request.Password);

            string id = await _userService.CreateUserAsync(request, hash);
            var token = _authService.CreateToken(id);

            return Ok(token);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var user = await _userService.GetUser("Username", request.Username);
            if (user is null) return BadRequest("User doesn't exist");
            if (!_authService.ValidatePassword(request.Password, user.Password)) return BadRequest("Wrong password");
            return Ok(_authService.CreateToken(user.Id));
        }

    }
}
