using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoLib.Application.Authentication.DTOs;
using PhotoLib.Domain.Entities;
using PhotoLib.Infrastructure.Persistence;
using PhotoLib.Application.Authentication.Interfaces;
namespace PhotoLib.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly PhotoLibDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthController(
    PhotoLibDbContext context,
    IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (existingUser != null)
        {
            return BadRequest(new
            {
                Message = "Email already exists"
            });
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            Message = "User registered successfully",
            user.Email
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user == null)
        {
            return Unauthorized(new
            {
                Message = "Invalid email or password"
            });
        }

        var validPassword = BCrypt.Net.BCrypt.Verify(
            request.Password,
            user.PasswordHash);

        if (!validPassword)
        {
            return Unauthorized(new
            {
                Message = "Invalid email or password"
            });
        }

        var token = _jwtTokenGenerator.GenerateToken(
            user.Id,
            user.Email);

        return Ok(new AuthResponse(
            token,
            user.Email));
    }
}