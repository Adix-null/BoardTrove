﻿using BoardTroveAPI.Data;
using BoardTroveAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using static BoardTroveAPI.Data.UtilMisc;

namespace BoardTroveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(APIContext context) : ControllerBase
    {
        private readonly APIContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<BasePost>>> GetAllPosts()
        {
            return Ok(await _context.Posts.ToListAsync());
        }

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
        public async Task<ActionResult<BasePost>> SubmitPost(/*[FromQuery] string? type,*/ BasePost newPost)
        {
            if (newPost == null)
            {
                return BadRequest();
            }
            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(SubmitPost), new { id = newPost.ID }, newPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(string id, BasePost updatedPost)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            if (post.GetType() != updatedPost.GetType())
            {
                return Conflict("Post types do not match");
            }

            post.Title = updatedPost.Title;
            post.Description = updatedPost.Description;
            CopyDerivedProperties(post, updatedPost);

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
