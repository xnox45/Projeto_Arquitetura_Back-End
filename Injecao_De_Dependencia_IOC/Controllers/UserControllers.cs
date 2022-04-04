using Microsoft.AspNetCore.Mvc;
using System;
using Template.Application.Interface;
using Template.Application.ViewModel;
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
        public IActionResult Post(UserViewModel model)
        {
            bool result = this._userService.Post(model);

            return Ok(result.ToString() + "\nUsuario salvo");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid userID))
                    throw new Exception("UserID is not valid");

                return Ok(this._userService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpPut]
        public IActionResult Update(UserViewModel model)
        {
            try
            {
                return Ok(_userService.Put(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
