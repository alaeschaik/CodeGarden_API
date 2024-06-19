using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Module;

[Route("api/[controller]")]
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
        };

        context.Modules.Add(module);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetModule), new { id = module.Id }, module);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Module>> GetModule(int id)
    {
        var module = await context.Modules.FindAsync(id);

        if (module == null)
        {
            return NotFound();
        }

        return module;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Module>>> GetModules()
    {
        return await context.Modules.ToListAsync();
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateModule(int id, Models.Module module)
    {
        if (id != module.Id)
        {
            return BadRequest();
        }

        context.Entry(module).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ModuleExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteModule(int id, CancellationToken cancellationToken)
    {
        var module = await context.Modules.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        if (module == null)
        {
            return NotFound();
        }

        context.Modules.Remove(module);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/sections")]
    public async Task<ActionResult<IEnumerable<Models.Section>>> GetSectionsForModule(int id,
        CancellationToken cancellationToken)
    {
        var module = await context.Modules.Include(m => m.Sections)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        return module?.Sections?.ToList() ?? [];
    }

    private bool ModuleExists(int id)
    {
        return context.Modules.Any(e => e.Id == id);
    }
}