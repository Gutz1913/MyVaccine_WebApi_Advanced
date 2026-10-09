using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.WebApi.DTOs.Request;
using MyVaccine.WebApi.Literals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyVaccine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
    {
        //if (!result.Succeeded)
        //{
        //    return BadRequest(result.Errors);
        //}

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(MyVaccineLiterals.JWT_KEY)));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                //issuer: _configuration["JwtIssuer"],
                //audience: _configuration["JwtAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15), //Tiempo de vida del token
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        return Unauthorized();
    }
}
