using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Post;

[Route("api/[controller]")]
[ApiController]
public class PostsController(CodeGardenContext context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Models.Post>> CreatePost(
        [FromBody] CreatePostDto createPostDto,
        CancellationToken cancellationToken)
    {
        var doesPostExist = await context.Posts.AnyAsync(
            p => p.Title == createPostDto.Title, cancellationToken);

        if (doesPostExist)
        {
            return BadRequest($"Post with the title {createPostDto.Title} already exists");
        }

        var post = new Models.Post
        {
            UserId = createPostDto.UserId ?? throw new ArgumentNullException(nameof(createPostDto)),
            Title = createPostDto.Title ?? throw new ArgumentNullException(nameof(createPostDto)),
            Content = createPostDto.Content ?? throw new ArgumentNullException(nameof(createPostDto)),
        };
        context.Posts.Add(post);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.Post>> GetPost(int id)
    {
        var post = await context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        return post;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Post>>> GetPosts()
    {
        return await context.Posts.ToListAsync();
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePost(int id, Models.Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }

        context.Entry(post).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        context.Posts.Remove(post);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:int}/comments")]
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetPostComments(int id)
    {
        var post = await context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        if (post == null)
        {
            return NotFound();
        }

        return post.Comments?.ToList() ?? [];
    }
    
    [Authorize]
    [HttpGet("{id:int}/user")]
    public async Task<ActionResult<Models.User>> GetPostUser(int id)
    {
        var post = await context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        if (post?.User == null)
        {
            return NotFound();
        }

        return post.User;
    }

    private bool PostExists(int id)
    {
        return context.Posts.Any(e => e.Id == id);
    }
}