using Microsoft.AspNetCore.Mvc;
using WepApiEcommerceIDYGS91.Data;
using WepApiEcommerceIDYGS91.Models;
using WepApiEcommerceIDYGS91.Tools;

namespace WepApiEcommerceIDYGS91.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UsersController(ApplicationDBContext _context)
        {
            this._context = _context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> userLogin([FromBody] UserLogin user)
        {
            try
            {
                string password = Password.hasPassword(user.Password);
                var dbContextUser = _context.Users.Where(u => u.UserName == user.UserName && u.Password == password).FirstOrDefault();

                if (dbContextUser == null)
                {
                    return BadRequest("Username or password is incorrect");
                }

                return Ok(dbContextUser);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> userRegistration([FromBody] User user)
        {
            try
            {
                var dbContextUser = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (dbContextUser != null)
                {
                    return BadRequest("username already exists");
                }

                user.Password = Password.hasPassword(user.Password);
                user.IsActive = 1;
                user.RolId = 1;
                _context.Users.Add(user);
                _context.SaveChangesAsync();

                return Ok("User is succesfully registered");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

           
        }
    }
}
