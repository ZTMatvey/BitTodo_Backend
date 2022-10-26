using AutoMapper;
using BitTodo.Domain.DTOs.Request;
using BitTodo.Domain.DTOs.Response;
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
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Group> _groups;
        private readonly IRepository<Domain.Models.Task> _tasks;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, IRepository<Group> groups, IMapper mapper, IRepository<Domain.Models.Task> tasks)
        {
            _userManager = userManager;
            _groups = groups;
            _mapper = mapper;
            _tasks = tasks;
        }

        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroup(AddGroupDTO model)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                _groups.Insert(new Group() { Name = model.Name, UserId = userId });
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask(AddTaskDTO model)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                var task = _mapper.Map<Domain.Models.Task>(model);
                task.UserId = userId;
                task.DateTime = DateTime.Now;
                _tasks.Insert(task);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("SetCompletedState")]
        public async Task<IActionResult> SetCompletedState(SetCompletedStateDTO model)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                var task = _tasks.Get(model.TaskId);
                if (task == null)
                    return BadRequest("Task not found");
                task.IsCompleted = model.State; ;
                _tasks.Update(task);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("DeleteTask")]
        public async Task<IActionResult> DeleteTask(DeleteTaskDTO model)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                var task = _tasks.Get(model.TaskId);
                if (task == null || task.UserId != userId)
                    return BadRequest("Task not found");
                _tasks.Delete(task);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Groups")]
        public async Task<IActionResult> GetGroups()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                var groups = _groups.GetWhere(x=>x.UserId == userId);
                var result = _mapper.Map<IEnumerable<GroupDTO>>(groups);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Tasks")]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "id").Value;
                var tasks = _tasks.GetWhere(x=>x.UserId == userId);
                var result = _mapper.Map<IEnumerable<TaskDTO>>(tasks);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
