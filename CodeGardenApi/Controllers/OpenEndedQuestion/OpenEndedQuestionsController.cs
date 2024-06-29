using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.OpenEndedQuestion;

[Route("api/open-ended-questions")]
[ApiController]
public class OpenEndedQuestionsController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.OpenEndedQuestion>> CreateOpenEndedQuestion(
        [FromBody] CreateOpenEndedQuestionDto createOpenEndedQuestionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createOpenEndedQuestionDto);
        ArgumentNullException.ThrowIfNull(createOpenEndedQuestionDto.Content);
        ArgumentNullException.ThrowIfNull(createOpenEndedQuestionDto.CorrectAnswer);

        var doesOpenEndedQuestionExist = await context.OpenEndedQuestions.AnyAsync(
            m => m.Content == createOpenEndedQuestionDto.Content, cancellationToken);

        if (doesOpenEndedQuestionExist)
        {
            return BadRequest($"OpenEndedQuestion with the content {createOpenEndedQuestionDto.Content} already exists");
        }

        var openEndedQuestion = new Models.OpenEndedQuestion
        {
            Content = createOpenEndedQuestionDto.Content,
            CorrectAnswer = createOpenEndedQuestionDto.CorrectAnswer
        };

        context.OpenEndedQuestions.Add(openEndedQuestion);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetOpenEndedQuestion), new { id = openEndedQuestion.Id }, openEndedQuestion);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.OpenEndedQuestion>>> GetOpenEndedQuestions(CancellationToken cancellationToken)
    {

        var openEndedQuestions = await context.OpenEndedQuestions
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return openEndedQuestions;
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.OpenEndedQuestion>> GetOpenEndedQuestion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var openEndedQuestion = await context.OpenEndedQuestions.AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (openEndedQuestion is null) return NotFound();

        return openEndedQuestion;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOpenEndedQuestion(
        [FromRoute] int id,
        [FromBody] UpdateOpenEndedQuestionDto updateOpenEndedQuestionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateOpenEndedQuestionDto);

        var openEndedQuestion = await context.OpenEndedQuestions.FindAsync([id], cancellationToken);

        if (openEndedQuestion is null)
        {
            return NotFound();
        }

        openEndedQuestion.Content = updateOpenEndedQuestionDto.Content ?? openEndedQuestion.Content;
        openEndedQuestion.CorrectAnswer = updateOpenEndedQuestionDto.CorrectAnswer ?? openEndedQuestion.CorrectAnswer;

        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOpenEndedQuestion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var openEndedQuestion = await context.OpenEndedQuestions.FindAsync([id, cancellationToken], cancellationToken);
        if (openEndedQuestion is null)
        {
            return NotFound();
        }

        context.OpenEndedQuestions.Remove(openEndedQuestion);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
    
    [Authorize]
    [HttpPost("{id}/answer")]
    public async Task<IActionResult> SubmitAnswer(
        [FromRoute] int id,
        [FromBody] CreateOpenEndedQuestionDto createOpenEndedQuestionDto,
        CancellationToken cancellationToken)
    {

        var openEndedQuestion = await context.OpenEndedQuestions.FindAsync([id], cancellationToken);

        if (openEndedQuestion is null)
        {
            return NotFound();
        }

        if (openEndedQuestion.CorrectAnswer == createOpenEndedQuestionDto.Content)
        {
            return Ok("Correct Answer");
        }

        return Ok("Incorrect Answer");
    }
    
}
