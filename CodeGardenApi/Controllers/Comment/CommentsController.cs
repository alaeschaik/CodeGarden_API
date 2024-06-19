using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Comment;

[Route("api/[controller]")]
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
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Comment>> GetComment(int id)
    {
        var comment = await context.Comments.FindAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [Authorize]
    [HttpGet("post/{postId:int}")]
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetCommentsForPost(int postId)
    {
        return await context.Comments.Where(c => c.PostId == postId).ToListAsync();
    }
    
    [Authorize]
    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetCommentsForUser(int userId)
    {
        return await context.Comments.Where(c => c.UserId == userId).ToListAsync();
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateComment(int id, Models.Comment comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }

        context.Entry(comment).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommentExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();

        return NoContent();
    }
    
    

    private bool CommentExists(int id)
    {
        return context.Comments.Any(e => e.Id == id);
    }
}
