using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Module;

[Route("api/modules")]
[ApiController]
public class ModulesController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Module>> CreateModule(
        [FromBody] CreateModuleDto createModuleDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createModuleDto);
        ArgumentNullException.ThrowIfNull(createModuleDto.Title);
        ArgumentNullException.ThrowIfNull(createModuleDto.Description);
        ArgumentNullException.ThrowIfNull(createModuleDto.Content);
        ArgumentNullException.ThrowIfNull(createModuleDto.Introduction);
        ArgumentNullException.ThrowIfNull(createModuleDto.TotalXpPoints);

        var doesModuleExist = await context.Modules.AnyAsync(
            m => m.Title == createModuleDto.Title, cancellationToken);

        if (doesModuleExist)
        {
            return BadRequest($"Module with the title {createModuleDto.Title} already exists");
        }

        var module = new Models.Module
        {
            Title = createModuleDto.Title,
            Description = createModuleDto.Description,
            Introduction = createModuleDto.Introduction,
            TotalXpPoints = (decimal)createModuleDto.TotalXpPoints,
            Content = createModuleDto.Content,
            Sections = new List<Models.Section>()
        };

        context.Modules.Add(module);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetModule), new { id = module.Id }, module);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Module>>> GetModules(CancellationToken cancellationToken)
    {
        // TODO: add pagination
        return await context.Modules
            .AsNoTracking()
            .Include(m => m.Sections)
            .ToListAsync(cancellationToken);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Module>> GetModule(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var module = await context.Modules.AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (module is null) return NotFound();

        return module;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateModule(
        [FromRoute] int id,
        [FromBody] UpdateModuleDto updateModuleDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateModuleDto);

        var module = await context.Modules.FindAsync([id], cancellationToken);

        if (module is null)
        {
            return NotFound();
        }

        module.Title = updateModuleDto.Title ?? module.Title;
        module.Description = updateModuleDto.Description ?? module.Description;
        module.Introduction = updateModuleDto.Introduction ?? module.Introduction;
        module.Content = updateModuleDto.Content ?? module.Content;
        module.TotalXpPoints = updateModuleDto.TotalXpPoints ?? module.TotalXpPoints;

        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteModule(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var module = await context.Modules.FindAsync([id, cancellationToken], cancellationToken);
        if (module is null)
        {
            return NotFound();
        }

        context.Modules.Remove(module);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/sections")]
    public async Task<ActionResult<IEnumerable<Models.Section>>> GetSectionsForModule(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var module = await context.Modules.AsNoTracking()
            .Include(m => m.Sections)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        return module?.Sections?.ToList() ?? [];
    }
}