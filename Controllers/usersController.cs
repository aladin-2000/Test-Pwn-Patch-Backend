using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_Pwn_Pach.Data;
using test_Pwn_Pach.Models;

namespace test_Pwn_Pach.Controllers
{
    [ApiController]
    [Route("test")]
    public class usersController : Controller
    {
        private readonly UsersDbContexte usersDbContexte;
        public usersController(UsersDbContexte usersDbContexte)
        {
            this.usersDbContexte = usersDbContexte;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await usersDbContexte.Users.ToListAsync();
            return Ok(users);
        }
        // GET ONE USER
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetOneUser")]
        public async Task<IActionResult> GetOneUser([FromRoute] Guid id)
        {
            var user = await usersDbContexte.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("user not found");
        }

        // ADD ONE USER
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await usersDbContexte.Users.AddAsync(user);
            await usersDbContexte.SaveChangesAsync();
            return Ok(user);
        }

        // UPDATE ONE USER
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] User user)
        {
            var existingUser = await usersDbContexte.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser != null)
            {
                existingUser.phone = user.phone;
                existingUser.lastName = user.lastName;
                existingUser.firstName = user.firstName;
                existingUser.role = user.role;
                existingUser.email = user.email;
                existingUser.password = user.password;
                await usersDbContexte.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User Not Found");

        }



        // Delete ONE USER
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeeleteUser([FromRoute] Guid id)
        {
            var existingUser = await usersDbContexte.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser != null)
            {
                usersDbContexte.Remove(existingUser);
                await usersDbContexte.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User Not Found");

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User userLogin)
        {
            var user = await usersDbContexte.Users.FirstOrDefaultAsync(x => x.email == userLogin.email);

            if (user != null)
            {
                if (user.password == userLogin.password)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Incorrect password");
                }
            }
            return NotFound("User not found");
        }



    }
}
