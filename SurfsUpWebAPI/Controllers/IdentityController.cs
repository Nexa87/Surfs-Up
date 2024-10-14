using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfsUpWebAPI.Models;

namespace SurfsUpWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
               
        // GET: api/identity/users
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
    }

}
