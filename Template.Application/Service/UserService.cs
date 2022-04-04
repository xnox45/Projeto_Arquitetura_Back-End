using AutoMapper;
using System;
using System.Collections.Generic;
using Template.Application.Interface;
using Template.Application.ViewModel;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();

            IEnumerable<User> users = _userRepository.GetAll();

            //foreach (var item in users)
            //    userViewModels.Add(new UserViewModel {Id = item.Id, Name = item.Name, Mail = item.Mail});

            userViewModels = _mapper.Map<List<UserViewModel>>(users);

            return userViewModels;
        } 

        public bool Post(UserViewModel model)
        {
            //User user = new User()
            //{
            //    Id = new Guid(),
            //    Name = model.Name,
            //    Mail = model.Mail,
            //};

            User user = _mapper.Map<User>(model);

            _userRepository.Create(user);

            return true;
        }
    }
}
