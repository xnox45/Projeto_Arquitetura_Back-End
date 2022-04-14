using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Template.Application.Service;
using Template.Application.Tests.ConfigTest;
using Template.Application.ViewModel;
using Template.Domain.Entities;
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

        #region ValidatingSendingId
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

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => _userService.Delete(""));

            Assert.Equal("Id Empty", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            Exception exception = Assert.Throws<Exception>(() => _userService.Put(new UserViewModel()));

            Assert.Equal(Exceptions.Ex0003, exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        {
            Exception exception = Assert.Throws<Exception>(() => _userService.Authenticate(new UserAuthenticateRequestViewModel()));
            
            Assert.Equal("Email/Password are requeried", exception.Message);
        }
        #endregion

        #region ValidatingCorrectObject
        [Fact]
        public void Post_SendingValidObject() 
        {
            var result = _userService.Post(new UserViewModel {Name="Teste Unitario One" , Mail="Teste_Unitario1@example.com"});

            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            List<User> users = new List<User>();

            users.Add(new User { Id = Guid.NewGuid(), Name = "Teste Unitario two", Mail = "TesteUnitarioTwo@example.com" , CreationDate = DateTime.Now});

            var userRepository = new ConfigTests().MockGetIUserRepository(users);

            //Configurando Mock AuttoMapper
            IMapper mapper = new ConfigTests().MockAuttoMapper();

            _userService = new UserService(userRepository.Object, mapper);

            var result = _userService.Get();

            Assert.True(result.Count > 0);
        }
        #endregion

        #region ValidatingRequiredFields
        [Fact]
        public void Post_SendingInvalidObject()//Validando Requeried(UserViewModel.Mail) de DataAnnotation
        {
            Exception exception = Assert.Throws<ValidationException>(() => _userService.Post(new UserViewModel { Name="Teste Unitario invalid" }));

            Assert.Equal("Mail Empty", exception.Message);
        }

        #endregion
    }
}
