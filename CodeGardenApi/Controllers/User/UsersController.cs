using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CodeGardenApi.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UsersController(CodeGardenContext context, IConfiguration configuration) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<Models.User>> Register(
        [FromBody] RegisterUserDto registerUserDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(registerUserDto);
        ArgumentNullException.ThrowIfNull(registerUserDto.Username);
        ArgumentNullException.ThrowIfNull(registerUserDto.Email);
        ArgumentNullException.ThrowIfNull(registerUserDto.Password);
        ArgumentNullException.ThrowIfNull(registerUserDto.Firstname);
        ArgumentNullException.ThrowIfNull(registerUserDto.Lastname);

        var doesUserExist = await context.Users.AnyAsync(
            u => u.Email == registerUserDto.Email || u.Username == registerUserDto.Username, cancellationToken);

        if (doesUserExist)
        {
            return BadRequest("User already exists");
        }

        var user = new Models.User
        {
            Username = registerUserDto.Username,
            Email = registerUserDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password),
            Firstname = registerUserDto.Firstname,
            Lastname = registerUserDto.Lastname,
            CreatedAt = DateTime.Now
        };

        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginModel login,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Email == login.Email, cancellationToken);
        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            return Unauthorized();
        }

        var token = GenerateJwtToken(user);

        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.User>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.User>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    [Authorize]
    [HttpPut("{id:int}/reset-password")]
    public async Task<IActionResult> ChangePassword(
        int id,
        [FromBody] ResetPasswordDto resetPasswordDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resetPasswordDto);
        ArgumentNullException.ThrowIfNull(resetPasswordDto.OldPassword);
        ArgumentNullException.ThrowIfNull(resetPasswordDto.NewPassword);

        var user = await context.Users.FindAsync([id], cancellationToken: cancellationToken);
        if (user == null)
        {
            return NotFound();
        }

        if (!BCrypt.Net.BCrypt.Verify(resetPasswordDto.OldPassword, user.Password))
        {
            return BadRequest("Old password is incorrect");
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(resetPasswordDto.NewPassword);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    private string GenerateJwtToken(Models.User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException()));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [Authorize]
    [HttpGet("{id:int}/posts")]
    public async Task<ActionResult<IEnumerable<Models.Post>>> GetPosts(int id)
    {
        var user = await context.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return user.Posts?.ToList() ?? [];
    }

    [Authorize]
    [HttpGet("{id:int}/comments")]
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetComments(int id)
    {
        var user = await context.Users.Include(u => u.Comments).FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return user.Comments?.ToList() ?? [];
    }
}