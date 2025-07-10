using BoardTroveAPI.Data;
using BoardTroveAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BoardTroveAPI.Controllers
{
    public class AuthController
    {

        //private readonly APIContext _context;

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest request)
        //{
        //    var user = _context.Users.SingleOrDefault(u => u.Username == request.Email && u.Password == request.Password); // Use hashed passwords in real use
        //    if (user == null)
        //        return Not();

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim(ClaimTypes.Role, "User")
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "yourdomain.com",
        //        audience: "yourdomain.com",
        //        claims: claims,
        //        expires: DateTime.Now.AddHours(2),
        //        signingCredentials: creds
        //    );

        //    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //}

    }
}
