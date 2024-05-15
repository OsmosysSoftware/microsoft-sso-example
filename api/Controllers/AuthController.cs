using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace MyDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("microsoft")]
        public async Task<IActionResult> MicrosoftLogin([FromBody] TokenDto tokenDto)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(tokenDto.Token) as JwtSecurityToken;

            if (jsonToken == null) return Unauthorized();

            var userEmail = jsonToken.Claims.First(claim => claim.Type == "preferred_username").Value;

            var user = await GetUserByEmail(userEmail);
            var jwt = GenerateJwtForUser(user);

            return Ok(new { token = jwt, user = user });
        }

        private Task<User> GetUserByEmail(string email)
        {
            return Task.FromResult(new User { Email = email });
        }

        private string GenerateJwtForUser(User user)
        {
            return "your-generated-jwt";
        }
    }

    public class TokenDto
    {
        public string? Token { get; set; }
    }

    public class User
    {
        public string? Email { get; set; }
    }
}
