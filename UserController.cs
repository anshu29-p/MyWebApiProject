using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new User { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
        };

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            user.Id = users.Count + 1;
            users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            users.Remove(user);
            return NoContent();
        }
    }
}
