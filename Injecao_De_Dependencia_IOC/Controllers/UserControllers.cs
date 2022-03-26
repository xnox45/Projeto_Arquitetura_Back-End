using Microsoft.AspNetCore.Mvc;
using Template.Application.Interface;

namespace Api.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;

        public UserControllers(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this._userService.Test();

            return Ok("Ok");
        }
    }
}
