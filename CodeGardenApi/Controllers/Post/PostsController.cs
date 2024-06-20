using CodeGardenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Controllers.Post;

[Route("api/posts")]
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
    public async Task<ActionResult<Models.Post>> GetPost([FromRoute] int id)
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
    public async Task<IActionResult> UpdatePost(
        [FromRoute] int id,
        [FromBody] UpdatePostDto updatePostDto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updatePostDto);
        //TODO: use fluent validation

        var post = await context.Posts.FindAsync([id], cancellationToken);

        if (post is null)
        {
            return NotFound();
        }

        post.Title = updatePostDto.Title ?? post.Title;
        post.Content = updatePostDto.Content ?? post.Content;
        post.Upvotes = updatePostDto.Upvotes ?? post.Upvotes;
        post.Downvotes = updatePostDto.Downvotes ?? post.Downvotes;

        await context.SaveChangesAsync(cancellationToken);


        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePost([FromRoute] int id)
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
    public async Task<ActionResult<IEnumerable<Models.Comment>>> GetPostComments([FromRoute] int id)
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
    public async Task<ActionResult<Models.User>> GetPostUser([FromRoute] int id)
    {
        var post = await context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        if (post?.User == null)
        {
            return NotFound();
        }

        return post.User;
    }
}