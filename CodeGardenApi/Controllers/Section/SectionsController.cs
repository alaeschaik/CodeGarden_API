using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Section;

[Route("api/[Controller]")]
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
        ArgumentNullException.ThrowIfNull(createSectionDto.ModuleId);
        ArgumentNullException.ThrowIfNull(createSectionDto.XpPoints);
        
        var doesSectionExist = await context.Sections.AnyAsync(
            s => s.Title == createSectionDto.Title, cancellationToken);
        
        if(doesSectionExist)
        {
            return BadRequest($"Section with the title {createSectionDto.Title} already exists");
        }
        
        var section = new Models.Section
        {
            Title = createSectionDto.Title,
            ModuleId = (int)createSectionDto.ModuleId,
            XpPoints = (decimal)createSectionDto.XpPoints,
        };
        
        context.Sections.Add(section);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetSection), new { id = section.Id }, section);
    }
    
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Section>>> GetSections()
    {
        return await context.Sections.ToListAsync();
    }
    
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Section>> GetSection(int id)
    {
        var section = await context.Sections.FindAsync(id);

        if (section == null)
        {
            return NotFound();
        }

        return section;
    }
    
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateSection(int id, Models.Section section)
    {
        if (id != section.Id)
        {
            return BadRequest();
        }
        
        context.Entry(section).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SectionExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSection(int id)
    {
        var section = await context.Sections.FindAsync(id);
        if (section == null)
        {
            return NotFound();
        }

        context.Sections.Remove(section);
        await context.SaveChangesAsync();

        return NoContent();
    }
    
    [Authorize]
    [HttpGet("{id:int}/module")]
    public async Task<ActionResult<Models.Module>> GetSectionsForModule(int id)
    {
        var module =  await context.Sections.Include(s => s.Module)
            .Where(s => s.Id == id).FirstOrDefaultAsync();

        if (module?.Module is null)
        {
            return NotFound();
        }

        return module.Module;
    }
    
    [Authorize]
    [HttpGet("{id:int}/challenges")]
    public async Task<ActionResult<IEnumerable<Models.Section>>> GetChallenges(int id)
    {
        return await context.Sections.Include(s => s.Challenges).Where(s => s.Id == id).ToListAsync();
    }

    private bool SectionExists(int id)
    {
        return context.Sections.Any(e => e.Id == id);
    }
}