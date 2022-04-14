using AutoMapper;
using Moq;
using System.Collections.Generic;
using Template.Application.AutoMapper;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Tests.ConfigTest
{
    public class ConfigTests
    {

        public Mock<IUserRepository> MockGetIUserRepository(List<User> users)
        {
            var userRepository = new Mock<IUserRepository>();

            userRepository.Setup(x => x.GetAll()).Returns(users);

            return userRepository;
        }

        public IMapper MockAuttoMapper()
        {
            var auttoMapperProfile = new AutoMapperSetup();//configuração necessaria para que mock tenha as configurações de AuttoMapper utilizada no metodo get da UserService

            var configuration = new MapperConfiguration(x => x.AddProfile(auttoMapperProfile));

            IMapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}
