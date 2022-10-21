using BitTodo.Domain.Dtos;
using BitTodo.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BitTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<object> Register(UserRegistrationDto model)
        {
            var appUser = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email,
            };

            try
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(123);
        }
    }
}
