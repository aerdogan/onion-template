using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

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
        public IActionResult GetList()
        {
            var result = _userService.GetAllAsync();
            if (result != null ) return Ok(result);
            return BadRequest();
        }

        [HttpGet("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.AddAsync(user);
            if (result != null) return Ok(result);
            return BadRequest();
        }

        [HttpGet("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.UpdateAsync(user);
            if (result != null) return Ok(result);
            return BadRequest();
        }
    }
}
