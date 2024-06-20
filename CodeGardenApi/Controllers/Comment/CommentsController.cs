using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Comment;

[Route("api/comments")]
[ApiController]
public class CommentsController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Comment>> CreateComment(
        [FromBody] CreateCommentDto createCommentDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createCommentDto);
        ArgumentNullException.ThrowIfNull(createCommentDto.UserId);
        ArgumentNullException.ThrowIfNull(createCommentDto.PostId);
        ArgumentNullException.ThrowIfNull(createCommentDto.Content);

        var comment = new Models.Comment
        {
            UserId = (int)createCommentDto.UserId,
            PostId = (int)createCommentDto.PostId,
            Content = createCommentDto.Content,
        };
        context.Comments.Add(comment);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetComments(CancellationToken cancellationToken)
    {
        return await context.Comments.ToListAsync(cancellationToken);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Comment>> GetComment(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var comment = await context.Comments.FindAsync([id], cancellationToken);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [Authorize]
    [HttpGet("{id:int}/post")]
    public async Task<ActionResult<Models.Post>> GetPostForComment(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var comment = await context.Comments.Include(c => c.Post).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (comment?.Post == null)
        {
            return NotFound();
        }

        return comment.Post;
    }

    [Authorize]
    [HttpGet("{id:int}/user")]
    public async Task<ActionResult<Models.User>> GetCommentsForUser(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var comment = await context.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (comment?.User == null)
        {
            return NotFound();
        }

        return comment.User;
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateComment(
        [FromRoute] int id,
        [FromBody] UpdateCommentDto updateCommentDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updateCommentDto);

        var comment = await context.Comments.FindAsync([id], cancellationToken);

        if (comment is null) return NotFound();

        comment.Content = updateCommentDto.Content ?? comment.Content;
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteComment(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var comment = await context.Comments.FindAsync([id], cancellationToken);
        if (comment == null)
        {
            return NotFound();
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}