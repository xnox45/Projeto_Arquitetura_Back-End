using Microsoft.AspNetCore.Mvc;
using System;
using Template.Application.Interface;
using Template.Data.Context;
using Template.Domain.Entities;

namespace Api.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly TemplateContext _context;

        public UserControllers(IUserService userService, TemplateContext context)
        {
            this._userService = userService;

            this._context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this._userService.Test();

            return Ok("Ok");
        }
        
        [HttpPost]
        public IActionResult Post()
        {


            User user = new User()
            {
                UserId = new Guid()
                ,Name = "Teste Controller"
                ,Mail = "TestController@example.com"
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok("Ok");
        }
    }
}
