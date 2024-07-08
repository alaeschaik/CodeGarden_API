using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Question;

[Route("api/questions")]
[ApiController]
public class QuestionsController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Question>> CreateQuestion(
        [FromBody] CreateQuestionDto createQuestionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createQuestionDto);
        ArgumentNullException.ThrowIfNull(createQuestionDto.Content);
        ArgumentNullException.ThrowIfNull(createQuestionDto.CorrectAnswer);
        ArgumentNullException.ThrowIfNull(createQuestionDto.Type);
        ArgumentNullException.ThrowIfNull(createQuestionDto.XpPoints);

        var doesQuestionExist = await context.Questions.AnyAsync(
            m => m.Content == createQuestionDto.Content, cancellationToken);

        if (doesQuestionExist)
        {
            return BadRequest($"Question with the content {createQuestionDto.Content} already exists");
        }

        var question = new Models.Question
        {
            Content = createQuestionDto.Content,
            CorrectAnswer = createQuestionDto.CorrectAnswer,
            Type = createQuestionDto.Type ?? throw new ArgumentNullException(nameof(createQuestionDto)),
            XpPoints = (decimal)createQuestionDto.XpPoints,
        };

        context.Questions.Add(question);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Question>>> GetQuestions(CancellationToken cancellationToken)
    {

        var questions = await context.Questions
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return questions;
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Question>> GetQuestion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var question = await context.Questions.AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (question is null) return NotFound();

        return question;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateQuestion(
        [FromRoute] int id,
        [FromBody] UpdateQuestionDto updateQuestionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateQuestionDto);

        var question = await context.Questions.FindAsync([id], cancellationToken);

        if (question is null)
        {
            return NotFound();
        }

        question.Content = updateQuestionDto.Content ?? question.Content;
        question.CorrectAnswer = updateQuestionDto.CorrectAnswer ?? question.CorrectAnswer;
        question.Type = updateQuestionDto.Type ?? question.Type;
        question.XpPoints = updateQuestionDto.XpPoints ?? question.XpPoints;

        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteQuestion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var question = await context.Questions.FindAsync([id, cancellationToken], cancellationToken);
        if (question is null)
        {
            return NotFound();
        }

        context.Questions.Remove(question);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
    
    [Authorize]
    [HttpGet("{id:int}/choices")]
    public async Task<IActionResult> GetChoicesForQuestion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var question = await context.Questions.AsNoTracking()
            .Include(q => q.Choices)
            .FirstOrDefaultAsync(q => q.Id == id, cancellationToken);

        return new OkObjectResult(question?.Choices ?? []);
    }
    
    [Authorize]
    [HttpPost("{id:int}/answer")]
    public async Task<IActionResult> SubmitAnswer(
        [FromRoute] int id,
        [FromBody] AnswerQuestionDto answerQuestionDto,
        CancellationToken cancellationToken)
    {
        if (answerQuestionDto.Answer == null) throw new ArgumentNullException(nameof(answerQuestionDto.Answer));

        var question = await context.Questions.FindAsync([id], cancellationToken);

        if (question is null)
        {
            return NotFound();
        }

        if (question.CorrectAnswer == answerQuestionDto.Answer)
        {
            return Ok("Correct Answer");
        }

        return BadRequest("Incorrect Answer");
    }
}
