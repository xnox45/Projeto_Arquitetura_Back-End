using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Template.Application.Interface;
using Template.Application.ViewModel;
using Template.Auth.Services;
using Template.Data.Context;
using Template.Domain.Language;

namespace Template.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]//Authorize defini que todos os metodos dessa classe são privados mas tambem podemos colocar apenas para um metodo ser
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly TemplateContext _context;

        public UserControllers(IUserService userService, TemplateContext context)
        {
            this._userService = userService;

            this._context = context;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._userService.Get());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        
        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this._userService.Post(model));
        }

        [HttpGet("{id}")] //Permiti passar parametro para um metodo get
        public IActionResult GetById(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid userID))
                    throw new Exception(Exceptions.Ex0002);

                return Ok(this._userService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpPut, AllowAnonymous]
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
        
        [HttpDelete("{id}"), AllowAnonymous]//fazendo com que receba o id pela url
        public IActionResult Delete(string id)
        {
            try
            {
                //Pegando o Id do usuario direto da requisição, informando qual arfimação eu quero passar(Informei que o Id da classe User é o ClaimTypes.NameIdentifier)
                //string userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);//Pegando informações do token, como Id, email e etc
                
                return Ok(_userService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Auth"), AllowAnonymous]//AllowAnonymous defini que o metodo é publico e qualquer um pode acessar
        public IActionResult Auth(UserAuthenticateRequestViewModel model)
        {
            try
            {
                return Ok(this._userService.Authenticate(model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
