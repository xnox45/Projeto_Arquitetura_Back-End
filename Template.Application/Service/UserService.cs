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

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();

            IEnumerable<User> users = _userRepository.GetAll();

            foreach (var item in users)
                userViewModels.Add(new UserViewModel {Id = item.Id, Name = item.Name, Mail = item.Mail});

            return userViewModels;
        }
    }
}
