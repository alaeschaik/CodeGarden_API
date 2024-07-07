using CodeGardenApi.Data;
using CodeGardenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Discussions;

[Route("api/discussions")]
[ApiController]
public class DiscussionsController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Discussion>> CreateDiscussion(
        [FromBody] CreateDiscussionDto createDiscussion,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createDiscussion);
        ArgumentNullException.ThrowIfNull(createDiscussion.Title);
        ArgumentNullException.ThrowIfNull(createDiscussion.Content);
        ArgumentNullException.ThrowIfNull(createDiscussion.UserId);

        var discussion = new Discussion
        {
            Title = createDiscussion.Title,
            Content = createDiscussion.Content,
            UserId = createDiscussion.UserId,
            CreatedAt = DateTime.UtcNow,
            Contributions = []
        };
        context.Discussions.Add(discussion);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetDiscussion), new { id = discussion.Id }, discussion);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Discussion>>> GetDiscussions(CancellationToken cancellationToken)
    {
        return await context.Discussions.AsNoTracking()
            .Include(d => d.Contributions)!
            .ThenInclude(d => d.Contributions)
            .ToListAsync(cancellationToken);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Discussion>> GetDiscussion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var discussion = await context.Discussions.AsNoTracking()
            .Include(d => d.Contributions)!
            .ThenInclude(d => d.Contributions)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (discussion is null)
        {
            return NotFound();
        }

        return discussion;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Discussion>> UpdateDiscussion(
        [FromRoute] int id,
        [FromBody] UpdateDiscussionDto updateDiscussionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateDiscussionDto);
        ArgumentNullException.ThrowIfNull(updateDiscussionDto.Title);
        ArgumentNullException.ThrowIfNull(updateDiscussionDto.Content);

        var discussion = await context.Discussions.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (discussion is null)
        {
            return NotFound();
        }

        discussion.Title = updateDiscussionDto.Title;
        discussion.Content = updateDiscussionDto.Content;

        await context.SaveChangesAsync(cancellationToken);

        return discussion;
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDiscussion(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var discussion =
            await context.Discussions.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

        if (discussion is null)
        {
            return NotFound();
        }

        context.Discussions.Remove(discussion);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/user")]
    public async Task<ActionResult<Models.User>> GetUser(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var discussion = await context.Discussions.AsNoTracking()
            .Include(d => d.User)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (discussion?.User is null)
        {
            return NotFound();
        }

        return discussion.User;
    }


    [Authorize]
    [HttpPost("{id:int}/contributions")]
    public async Task<ActionResult<Contribution>> ContributeToDiscussion(
        [FromRoute] int id,
        [FromBody] CreateDiscussionContributionDto createDiscussionContributionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createDiscussionContributionDto);
        ArgumentNullException.ThrowIfNull(createDiscussionContributionDto.Content);
        ArgumentNullException.ThrowIfNull(createDiscussionContributionDto.UserId);

        var discussion =
            await context.Discussions.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (discussion is null)
        {
            return NotFound();
        }

        var contribution = new Contribution
        {
            Content = createDiscussionContributionDto.Content,
            UserId = createDiscussionContributionDto.UserId,
            DiscussionId = id,
            CreatedAt = DateTime.UtcNow,
            Contributions = []
        };
        context.Contributions.Add(contribution);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetContribution), new { id = discussion.Id, contributionId = contribution.Id },
            contribution);
    }

    [Authorize]
    [HttpGet("{id:int}/contributions")]
    public async Task<ActionResult<IEnumerable<Contribution>>> GetContributions(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var discussion = await context.Discussions.AsNoTracking()
            .Include(d => d.Contributions)!
            .ThenInclude(c => c.Contributions)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        return new OkObjectResult(discussion?.Contributions ?? []);
    }

    [Authorize]
    [HttpGet("{id:int}/contributions/{contributionId:int}")]
    public async Task<ActionResult<Contribution>> GetContribution(
        [FromRoute] int id,
        [FromRoute] int contributionId,
        CancellationToken cancellationToken)
    {
        var contribution = await context.Contributions.AsNoTracking()
            .Include(c => c.Contributions)!
            .ThenInclude(c => c.Contributions)
            .FirstOrDefaultAsync(c => c.DiscussionId == id && c.Id == contributionId, cancellationToken);

        if (contribution is null)
        {
            return NotFound();
        }

        return contribution;
    }

    [Authorize]
    [HttpPut("{id:int}/contributions/{contributionId:int}")]
    public async Task<ActionResult<Contribution>> UpdateContribution(
        [FromRoute] int id,
        [FromRoute] int contributionId,
        [FromBody] UpdateDiscussionContributionDto updateDiscussionContributionDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateDiscussionContributionDto);
        ArgumentNullException.ThrowIfNull(updateDiscussionContributionDto.Content);

        var contribution =
            await context.Contributions.FirstOrDefaultAsync(c => c.DiscussionId == id && c.Id == contributionId,
                cancellationToken);

        if (contribution is null)
        {
            return NotFound();
        }

        contribution.Content = updateDiscussionContributionDto.Content;

        await context.SaveChangesAsync(cancellationToken);

        return contribution;
    }

    [Authorize]
    [HttpDelete("{id:int}/contributions/{contributionId:int}")]
    public async Task<IActionResult> DeleteContribution(
        [FromRoute] int id,
        [FromRoute] int contributionId,
        CancellationToken cancellationToken)
    {
        var contribution =
            await context.Contributions.FirstOrDefaultAsync(c => c.DiscussionId == id && c.Id == contributionId,
                cancellationToken);

        if (contribution is null)
        {
            return NotFound();
        }

        context.Contributions.Remove(contribution);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/contributions/{contributionId:int}/contributions")]
    public async Task<ActionResult<IEnumerable<Contribution>>> GetContributionsForContribution(
        [FromRoute] int id,
        [FromRoute] int contributionId,
        CancellationToken cancellationToken)
    {
        var contribution = await GetContribution(id, contributionId, cancellationToken);
        return new OkObjectResult(contribution?.Value?.Contributions ?? []);
    }
}