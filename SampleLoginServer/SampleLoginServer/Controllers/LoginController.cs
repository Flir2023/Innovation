using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApplicaion.Models;

namespace WebApplicaion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private UsersDB usersDB;
        public LoginController()
        {
            usersDB = UsersDB.Instance();
        }

        // GET: api/TodoItems/5
        [HttpGet("{name}")]
        public async Task<ActionResult<bool>> GetTodoItem(String name)
        {
            var user = usersDB.UsersList.Find(x => x.Name == name);

            if (user == null)
            {
                return NotFound();
            }

            return true;
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostTodoItem(User user)
        {
            if (usersDB.UsersList.Find(x => x.Name == user.Name && x.Password == user.Password) == null)
                return NotFound();
            
            return CreatedAtAction(nameof(GetTodoItem), new { user.Name }, user);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> PostAddUser(User user)
        {
            if (usersDB.UsersList.Find(x => x.Name == user.Name && x.Password == user.Password) != null)
                return ValidationProblem();

            usersDB.UsersList.Add(user);
            return CreatedAtAction("GetTodoItem", new { user.Name }, user);
        }
    }
}
