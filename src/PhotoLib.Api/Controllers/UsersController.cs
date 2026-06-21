using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using PhotoLib.Infrastructure.Persistence;

namespace PhotoLib.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly PhotoLibDbContext _context;

    public UsersController(PhotoLibDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userIdClaim = User.FindFirst("sub")?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized();
        }

        var userId = Guid.Parse(userIdClaim);

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user.CreatedAt
        });
    }
}