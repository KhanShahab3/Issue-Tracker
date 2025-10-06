using IssueTracker.Api.Models;
using IssueTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IssueTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpGet]
        public  async Task<IActionResult> GetAllUsers()
        {
            var users=await _userService.GetUsers();
            if (users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);   
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {

                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users user)
        {
            var createdUser = await _userService.InsertUser(user);
            if (createdUser == null)
            {
                BadRequest();
            }


            return Ok(createdUser);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users user)
        {
            var updatedUser = await _userService.UpdateUser(user);
            if (updatedUser == null)
            {
                BadRequest();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteUser(int id)
        {
            var isDeleted=await _userService.DeleteUser(id);    
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
