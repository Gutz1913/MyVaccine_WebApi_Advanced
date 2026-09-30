using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.DTOs;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
    {
        var response = await _userService.AddUserAsync(model);
        if (response != null && response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        var response = await _userService.Login(model);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return Unauthorized(response);
        }
    }
}
