using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetByIdAsync(id);
            if (result != null) return Ok(result);
            return BadRequest();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetAllAsync();
            if (result != null ) return Ok(result);
            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(User user)
        {
            var result = await _userService.AddAsync(user);
            if (result) return Ok(result);
            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(User user)
        {
            var result = await _userService.UpdateAsync(user);
            if (result) return Ok(result);
            return BadRequest();
        }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result) return Ok(result);
            return BadRequest();
        }
    }
}
