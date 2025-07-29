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

            BasePost? castedPost;
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
            if (castedPost.UserId == null)
            {
                return NotFound("UserId missing");
            }
            var user = await _context.Users.FindAsync(castedPost.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            castedPost.User = user;

            _context.Posts.Add(castedPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(SubmitPost), new { id = castedPost.ID }, castedPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(string id, [FromBody] JsonElement updatedPost)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            BasePost? castedPost;
            try
            {
                castedPost = (BasePost)JsonSerializer.Deserialize(updatedPost.GetRawText(), post.GetType())!;
            }
            catch (InvalidCastException ex)
            {
                return BadRequest($"Failed to cast: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return BadRequest($"Failed to deserialize post json: {ex.Message}");
            }

            castedPost.User = null;
            post.Title = castedPost.Title;
            post.Description = castedPost.Description;
            //Does not work as of now
            CopyDerivedProperties(castedPost, post);

            await _context.SaveChangesAsync();
            return Ok(post);
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
