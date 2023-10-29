using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W43BankingAPI.Models;
using W43BankingAPI.Services;

namespace W43BankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            if (await _authorizationService.RegisterUser(user))
                return Ok();

            return BadRequest("Something went wrong.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await _authorizationService.Login(user))
            {
                string tokenString = _authorizationService.GenerateTokenString(user);
                return Ok(tokenString);
            }

            return Forbid();
        }
    }
}
