using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Presentation.Interface;
using Presentation.Model;
using Presentation.Services;
using CollectionSchedulingAPI.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollectionSchedulingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.RegisterAsync(model.Username, model.Password);
            return Ok(new { user.Id, user.Username });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao registrar o usuário: {ex.Message}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
    {
        try
        {
            var response = await _userService.AuthenticateAsync(model.Username, model.Password);
            if (response == null)
            {
                return Unauthorized();
            }

            var token = CreateToken(response.Data);
            return Ok(new { Token = token });
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao fazer o login do usuário: {ex.Message}");
        }
    }

    private string CreateToken(UserDto user)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }
}
