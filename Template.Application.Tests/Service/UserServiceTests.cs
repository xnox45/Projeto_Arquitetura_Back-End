using AutoMapper;
using Moq;
using System;
using Template.Application.Service;
using Template.Application.ViewModel;
using Template.Domain.Interfaces;
using Template.Domain.Language;
using Xunit;

namespace Template.Application.Tests.Service
{
    public class UserServiceTests
    {
        private UserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {   //Assert defini o tipo de retorno esperado para o teste(o teste a seguir mostra se caso tentarmos criar um novo usario e for implementado um id pelo o codigo, ele  deve retornar um erro)
            var exception = Assert.Throws<Exception>(() => _userService.Post(new UserViewModel(){Id = Guid.NewGuid()}));
            
            Assert.Equal(Exceptions.Ex0004, exception.Message);//Validando se é realmente a exception que estamos testando
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => _userService.GetById(""));

            Assert.Equal(Exceptions.Ex0003, exception.Message);
        }
    }
}
