using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.UserModule;

[Route("api/user-modules")]
[ApiController]

public class UserModulesController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.UserModule>> CreateUserModule(
        [FromBody] CreateUserModuleDto createUserModuleDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createUserModuleDto);
        ArgumentNullException.ThrowIfNull(createUserModuleDto.UserId);
        ArgumentNullException.ThrowIfNull(createUserModuleDto.ModuleId);
        ArgumentNullException.ThrowIfNull(createUserModuleDto.State);

        var doesUserModuleExist = await context.UserModules.AnyAsync(
            userModule => userModule.UserId == createUserModuleDto.UserId && userModule.ModuleId == createUserModuleDto.ModuleId, cancellationToken);

        if (doesUserModuleExist)
        {
            return BadRequest($"UserModule with the userId {createUserModuleDto.UserId} and moduleId {createUserModuleDto.ModuleId} already exists");
        }

        var userModule = new Models.UserModule
        {
            UserId = createUserModuleDto.UserId,
            ModuleId = createUserModuleDto.ModuleId,
            State = createUserModuleDto.State
        };

        context.UserModules.Add(userModule);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetUserModule), new { id = userModule.Id }, userModule);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.UserModule>>> GetUserModules(CancellationToken cancellationToken)
    {

        var userModules = await context.UserModules
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return userModules;
    }
    
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.UserModule>> GetUserModule(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var userModule = await context.UserModules.AsNoTracking()
            .FirstOrDefaultAsync(userModule => userModule.Id == id, cancellationToken);

        if (userModule is null) return NotFound();

        return userModule;
    }
    
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUserModule(
        [FromRoute] int id,
        [FromBody] UpdateUserModuleDto updateUserModuleDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateUserModuleDto);

        var userModule = await context.UserModules.FindAsync([id], cancellationToken);
        if (userModule is null)
        {
            return NotFound();
        }

        userModule.UserId = updateUserModuleDto.UserId ?? userModule.UserId;
        userModule.ModuleId = updateUserModuleDto.ModuleId ?? userModule.ModuleId;
        userModule.State = updateUserModuleDto.State ?? userModule.State;

        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUserModule(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var userModule = await context.UserModules.FindAsync([id, cancellationToken], cancellationToken);
        if (userModule is null)
        {
            return NotFound();
        }

        context.UserModules.Remove(userModule);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}
