using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static List<User> users = new();

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        users.Add(user);
        return Ok(new { message = "User registered" });
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var found = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (found == null) return Unauthorized();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("super_secret_key");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { token = tokenHandler.WriteToken(token) });
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        return Ok(new { username = User.Identity?.Name });
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}