using BoardTroveAPI.Data;
using BoardTroveAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BoardTroveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(APIContext context) : ControllerBase
    {
        private readonly APIContext _context = context;

        [HttpGet("{username}/usn")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<User>> GetUserByID(string ID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ID == ID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteUser(string ID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ID == ID);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
