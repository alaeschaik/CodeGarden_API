using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Section;

[Route("api/sections")]
[ApiController]
public class SectionsController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Section>> CreateSection(
        [FromBody] CreateSectionDto createSectionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createSectionDto);
        ArgumentNullException.ThrowIfNull(createSectionDto.Title);
        ArgumentNullException.ThrowIfNull(createSectionDto.Content);
        ArgumentNullException.ThrowIfNull(createSectionDto.ModuleId);
        ArgumentNullException.ThrowIfNull(createSectionDto.XpPoints);

        var doesSectionExist = await context.Sections.AnyAsync(
            s => s.Title == createSectionDto.Title, cancellationToken);

        if (doesSectionExist)
        {
            return BadRequest($"Section with the title {createSectionDto.Title} already exists");
        }

        var section = new Models.Section
        {
            Title = createSectionDto.Title,
            Content = createSectionDto.Content,
            ModuleId = (int)createSectionDto.ModuleId,
            XpPoints = (decimal)createSectionDto.XpPoints,
        };

        context.Sections.Add(section);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetSection), new { id = section.Id }, section);
    }


    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Section>>> GetSections(CancellationToken cancellationToken)
    {
        // TODO: add pagination
        return await context.Sections.AsNoTracking().ToListAsync(cancellationToken);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Section>> GetSection(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var section = await context.Sections.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (section is null) return NotFound();

        return section;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateSection(
        [FromRoute] int id,
        [FromBody] UpdateSectionDto updateSectionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateSectionDto);

        var section = await context.Sections.FindAsync([id], cancellationToken);

        if (section is null) return NotFound();

        section.Title = updateSectionDto.Title ?? section.Title;
        section.ModuleId = updateSectionDto.ModuleId ?? section.ModuleId;
        section.XpPoints = updateSectionDto.XpPoints ?? section.XpPoints;

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSection(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var section = await context.Sections.FindAsync([id], cancellationToken);
        if (section is null) return NotFound();

        context.Sections.Remove(section);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/module")]
    public async Task<ActionResult<Models.Module>> GetSectionsForModule(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var module = await context.Sections.AsNoTracking()
            .Include(s => s.Module)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (module?.Module is null) return NotFound();

        return module.Module;
    }

    [Authorize]
    [HttpGet("{id:int}/challenges")]
    public async Task<ActionResult<IEnumerable<Models.Section>>> GetChallenges(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        return await context.Sections.AsNoTracking()
            .Include(s => s.Challenges)
            .Where(s => s.Id == id)
            .ToListAsync(cancellationToken);
    }
}