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
            return Ok(this._userService.Get());
        }
        
        [HttpPost]
        public IActionResult Post()
        {


            User user = new User()
            {
                Id = new Guid()
               ,Name = "Teste Controller"
               ,Mail = "TestController@example.com"
               ,CreationDate = DateTime.Now
               ,UpdateDate = DateTime.Now
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok("Ok");
        }
    }
}
