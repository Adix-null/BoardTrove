using BoardTroveAPI.Data;
using BoardTroveAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text.Json;
using static BoardTroveAPI.Data.UtilMisc;

namespace BoardTroveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(APIContext context) : ControllerBase
    {
        private readonly APIContext _context = context;

        [HttpGet("random")]
        public async Task<ActionResult<BasePost>> GetRandomPost()
        {
            var posts = await _context.Posts.ToArrayAsync();
            if (posts.Length == 0)
            {
                return NotFound();
            }
            var random = new Random();

            return Ok(posts[random.Next(posts.Length)]);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasePost>> GetPostbyID(string id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BasePost>> SubmitPost([FromQuery] string type, [FromBody] JsonElement newPost)
        {
            Type? postType = null;
            if (TypesToModelNames[type] is Type modelType)
            {
                postType = modelType;
            }
            if (postType == null)
            {
                return BadRequest("Invalid post type");
            }

            BasePost? castedPost = null;
            try
            {
                castedPost = (BasePost)JsonSerializer.Deserialize(newPost.GetRawText(), postType)!;
            }
            catch (InvalidCastException ex)
            {
                return BadRequest($"Failed to cast: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return BadRequest($"Failed to deserialize post json: {ex.Message}");
            }

            _context.Posts.Add(castedPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(SubmitPost), new { id = castedPost.ID }, castedPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost([FromQuery] string id, [FromBody] JsonElement updatedPost)
        {
            var post = await _context.Posts.FindAsync(id);
            //var matchingType = post
            if (post == null)
            {
                return NotFound();
            }
            if (post.GetType() != updatedPost.GetType())
            {
                return Conflict("Post types do not match");
            }
            //todo: fix
            //post.Title = updatedPost.Title;
            //post.Description = updatedPost.Description;
            //CopyDerivedProperties(post, updatedPost);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
