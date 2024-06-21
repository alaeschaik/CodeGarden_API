using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CodeGardenApi.Controllers.User;

[Route("api/users")]
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
    public async Task<ActionResult<LoginResponse>> Login(
        [FromBody] LoginModel login,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(login);

        var isEmail = login.UsernameOrEmail!.Contains('@');

        var user = await context.Users.SingleOrDefaultAsync(
            u => isEmail ? u.Email == login.UsernameOrEmail : u.Username == login.UsernameOrEmail, cancellationToken);
        if (user is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            return Unauthorized();
        }

        var jwtToken = GenerateJwtToken(user);
        var response = new LoginResponse
        (
            Id: user.Id,
            Token: jwtToken.Token,
            ExpiresAt: jwtToken.Expiration,
            Username: user.Username
        );

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.User>> GetUser(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.User>>> GetUsers(CancellationToken cancellationToken)
    {
        // TODO: Add pagination
        return await context.Users.AsNoTracking().ToListAsync(cancellationToken);
    }

    [Authorize]
    [HttpPut("{id:int}/reset-password")]
    public async Task<IActionResult> ChangePassword(
        [FromRoute] int id,
        [FromBody] ResetPasswordDto resetPasswordDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resetPasswordDto);
        ArgumentNullException.ThrowIfNull(resetPasswordDto.OldPassword);
        ArgumentNullException.ThrowIfNull(resetPasswordDto.NewPassword);

        var user = await context.Users.FindAsync([id], cancellationToken: cancellationToken);
        if (user is null)
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

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUser(
        [FromRoute] int id,
        [FromBody] UpdateUserDto updateUserDto,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([id], cancellationToken);
        if (user is null ||
            await context.Users.AnyAsync(u => u.Username == updateUserDto.Username || u.Email == updateUserDto.Email,
                cancellationToken))
        {
            return BadRequest("Username or Email is already taken");
        }

        user.Username = updateUserDto.Username ?? user.Username;
        user.Email = updateUserDto.Email ?? user.Email;
        user.Firstname = updateUserDto.Firstname ?? user.Firstname;
        user.Lastname = updateUserDto.Lastname ?? user.Lastname;

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/posts")]
    public async Task<ActionResult<IEnumerable<Models.Post>>> GetPosts(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.AsNoTracking()
            .Include(u => u.Posts)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null) return NotFound();

        return user.Posts?.ToList() ?? [];
    }

    [Authorize]
    [HttpGet("{id:int}/comments")]
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetComments(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.AsNoTracking()
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null) return NotFound();

        return user.Comments?.ToList() ?? [];
    }

    private TokenResponse GenerateJwtToken(Models.User user)
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

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new TokenResponse(jwtToken, token.ValidTo.ToString("yyyy-MM-dd-HH:mm:ss"));
    }
}