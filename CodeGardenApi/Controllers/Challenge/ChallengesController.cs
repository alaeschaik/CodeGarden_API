using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Challenge;

[Route("api/challenges")]
[ApiController]
public class ChallengesController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Challenge>> CreateChallenge(
        [FromBody] CreateChallengeDto createChallengeDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createChallengeDto);
        ArgumentNullException.ThrowIfNull(createChallengeDto.ChallengeType);
        ArgumentNullException.ThrowIfNull(createChallengeDto.SectionId);
        ArgumentNullException.ThrowIfNull(createChallengeDto.Content);

        var challenge = new Models.Challenge
        {
            ChallengeType = ChallengeDtoHelper.ToChallengeTypeDto(createChallengeDto.ChallengeType),
            SectionId = (int)createChallengeDto.SectionId,
            Content = createChallengeDto.Content,
        };
        context.Challenges.Add(challenge);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetChallenge), new { id = challenge.Id }, challenge);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Challenge>> GetChallenge(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var challenge = await context.Challenges.AsNoTracking()
            .FirstOrDefaultAsync(ch => ch.Id == id, cancellationToken);

        if (challenge is null)
        {
            return NotFound();
        }

        return challenge;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Challenge>>> GetChallenges(CancellationToken cancellationToken)
    {
        return await context.Challenges.AsNoTracking().ToListAsync(cancellationToken);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateChallenge(
        [FromRoute] int id,
        [FromBody] UpdateChallengeDto updateChallengeDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateChallengeDto);

        var challenge =
            await context.Challenges.FindAsync([id], cancellationToken);

        if (challenge is null) return NotFound();

        challenge.Content = updateChallengeDto.Content ?? challenge.Content;
        challenge.SectionId = updateChallengeDto.SectionId ?? challenge.SectionId;
        challenge.ChallengeType = updateChallengeDto.ChallengeType != null
            ? ChallengeDtoHelper.ToChallengeTypeDto(updateChallengeDto.ChallengeType)
            : challenge.ChallengeType;

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteChallenge(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var challenge = await context.Challenges.FindAsync([id], cancellationToken);

        if (challenge is null) return NotFound();

        context.Challenges.Remove(challenge);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/section")]
    public async Task<ActionResult<Models.Section>> GetChallengesForSection(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var challenge = await context.Challenges.AsNoTracking()
            .Include(ch => ch.Section)
            .FirstOrDefaultAsync(ch => ch.Id == id, cancellationToken);

        if (challenge?.Section is null) return NotFound();

        return challenge.Section;
    }
    
    [Authorize]
    [HttpGet("{id:int}/questions")]
    public async Task<ActionResult<IEnumerable<Models.Question>>> GetQuestionsForChallenge(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var challenge = await context.Challenges.AsNoTracking()
            .Include(ch => ch.Questions)
            .FirstOrDefaultAsync(ch => ch.Id == id, cancellationToken);
        
        return new OkObjectResult(challenge?.Questions ?? []);
    }
}