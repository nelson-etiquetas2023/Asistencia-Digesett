using Digesett.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Digesett.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser() 
        {
            var users = await _context.User.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUsersById(int id) 
        {
            var user = _context.User.Where(u => u.Id == id);
            return Ok(user);
        } 
    }
}
