using CodeGardenApi.Controllers.Discussions;
using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Contributions;

[Route("api/contributions")]
[ApiController]
public class ContributionsController(CodeGardenContext context) : Controller
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Contribution>> CreateContribution(
        [FromBody] CreateContributionDto createContributionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createContributionDto);
        ArgumentNullException.ThrowIfNull(createContributionDto.DiscussionId);
        ArgumentNullException.ThrowIfNull(createContributionDto.UserId);
        ArgumentNullException.ThrowIfNull(createContributionDto.Content);

        var contribution = new Models.Contribution
        {
            DiscussionId = createContributionDto.DiscussionId,
            UserId = createContributionDto.UserId,
            Content = createContributionDto.Content,
            CreatedAt = DateTime.UtcNow,
        };

        context.Contributions.Add(contribution);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetContribution), new { id = contribution.Id }, contribution);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Contribution>>> GetContributions(
        CancellationToken cancellationToken)
    {
        return await context.Contributions.AsNoTracking()
            .Include(c => c.Contributions)!
            .ThenInclude(c => c.Contributions)!
            .ThenInclude(c => c.Contributions)
            .ToListAsync(cancellationToken);
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Contribution>> GetContribution(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.AsNoTracking()
            .Include(c => c.Contributions)!
            .ThenInclude(c => c.Contributions)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (contribution is null)
        {
            return NotFound();
        }

        return contribution;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Models.Contribution>> UpdateContribution(
        [FromRoute] int id,
        [FromBody] UpdateDiscussionContributionDto updateDiscussionContributionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateDiscussionContributionDto);
        ArgumentNullException.ThrowIfNull(updateDiscussionContributionDto.Content);

        var contribution = await context.Contributions.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (contribution is null)
        {
            return NotFound();
        }

        contribution.Content = updateDiscussionContributionDto.Content;
        await context.SaveChangesAsync(cancellationToken);

        return contribution;
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContribution(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (contribution is null)
        {
            return NotFound();
        }

        context.Contributions.Remove(contribution);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/discussion")]
    public async Task<ActionResult<Models.Discussion>> GetDiscussionForContribution(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.AsNoTracking()
            .Include(c => c.Discussion)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (contribution?.Discussion is null)
        {
            return NotFound();
        }

        return contribution.Discussion;
    }

    [Authorize]
    [HttpGet("{id:int}/user")]
    public async Task<ActionResult<Models.User>> GetUserForContribution(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.AsNoTracking()
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (contribution?.User is null)
        {
            return NotFound();
        }

        return contribution.User;
    }

    [Authorize]
    [HttpGet("{id:int}/contributions")]
    public async Task<ActionResult<IEnumerable<Models.Contribution>>> GetContributionsForContribution(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.AsNoTracking()
            .Include(c => c.Contributions)
            .ThenInclude(c => context.Contributions)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return new OkObjectResult(contribution?.Contributions ?? []);
    }

    [Authorize]
    [HttpGet("{id:int}/contributions/{contributionId:int}")]
    public async Task<ActionResult<Models.Contribution>> GetContributionForContribution(
        [FromRoute] int id,
        [FromRoute] int contributionId,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.AsNoTracking()
            .Include(c => c.Contributions)!
            .ThenInclude(c => c.Contributions)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return new OkObjectResult(contribution?.Contributions?.FirstOrDefault(c => c.Id == contributionId));
    }

    [Authorize]
    [HttpPost("{id:int}/contributions")]
    public async Task<ActionResult<Models.Contribution>> CreateContributionForContribution(
        [FromRoute] int id,
        [FromBody] CreateContributionDto createContributionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createContributionDto);
        ArgumentNullException.ThrowIfNull(createContributionDto.UserId);
        ArgumentNullException.ThrowIfNull(createContributionDto.Content);

        var parentContribution = await context.Contributions.Include(c => c.Contributions)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (parentContribution is null)
        {
            return NotFound();
        }

        var newContribution = new Models.Contribution
        {
            UserId = createContributionDto.UserId,
            Content = createContributionDto.Content,
            CreatedAt = DateTime.UtcNow,
            DiscussionId = createContributionDto.DiscussionId
        };

        parentContribution.Contributions?.Add(newContribution);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetContributionForContribution), new { id, contributionId = newContribution.Id },
            newContribution);
    }
}