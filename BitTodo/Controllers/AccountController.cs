using BitTodo.Domain.DTOs.Request;
using BitTodo.Domain.Models;
using BitTodo.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BitTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Group> _groups;

        public AccountController(UserManager<AppUser> userManager, IRepository<Group> groups)
        {
            _userManager = userManager;
            _groups = groups;
        }

        [HttpPost]
        [Authorize]
        [Route("AddGroup")]
        public async Task<IActionResult> AddGroup(AddGroupDTO model)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                var user = await _userManager.FindByIdAsync(userId);
                _groups.Insert(new Group() { Name = model.Name, UserId = user.Id });
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
