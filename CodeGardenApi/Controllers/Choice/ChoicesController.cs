using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Choice;

[Route("api/choices")]
[ApiController]
public class ChoicesController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Choice>> CreateChoice(
        [FromBody] CreateChoiceDto createChoiceDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createChoiceDto);
        ArgumentNullException.ThrowIfNull(createChoiceDto.Content);
        ArgumentNullException.ThrowIfNull(createChoiceDto.IsCorrect);

        var doesChoiceExist = await context.Choices.AnyAsync(
            m => m.Content == createChoiceDto.Content, cancellationToken);

        if (doesChoiceExist)
        {
            return BadRequest($"Choice with the content {createChoiceDto.Content} already exists");
        }

        var choice = new Models.Choice
        {
            Content = createChoiceDto.Content,
            IsCorrect = createChoiceDto.IsCorrect ?? false
        };

        context.Choices.Add(choice);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetChoice), new { id = choice.Id }, choice);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Choice>>> GetChoices(CancellationToken cancellationToken)
    {

        var choices = await context.Choices
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return choices;
    }
    
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Choice>> GetChoice(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var choice = await context.Choices.AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (choice is null) return NotFound();

        return choice;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateChoice(
        [FromRoute] int id,
        [FromBody] UpdateChoiceDto updateChoiceDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateChoiceDto);

        var choice = await context.Choices.FindAsync([id], cancellationToken);

        if (choice is null)
        {
            return NotFound();
        }

        choice.Content = updateChoiceDto.Content ?? choice.Content;
        choice.IsCorrect = updateChoiceDto.IsCorrect ?? choice.IsCorrect;

        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteChoice(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var choice = await context.Choices.FindAsync([id, cancellationToken], cancellationToken);
        if (choice is null)
        {
            return NotFound();
        }

        context.Choices.Remove(choice);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
    
    [Authorize]
    [HttpPost("{id}/answer")]
    public async Task<ActionResult<bool>> AnswerChoice(
        [FromRoute] int id, 
        [FromBody] CreateChoiceDto createChoiceDto, 
        CancellationToken cancellationToken)
    {
        var choice = await context.Choices.AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (choice == null)
        {
            return NotFound();
        }

        return choice.IsCorrect == createChoiceDto.IsCorrect;
    }
}