using AutoMapper;
using System;
using System.Collections.Generic;
using Template.Application.Interface;
using Template.Application.ViewModel;
using Template.Auth.Services;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Template.Domain.Language;

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

        public UserViewModel GetById(string id)
        {
            UserViewModel model = _mapper.Map<UserViewModel>(_userRepository.GetById(Guid.Parse(id)));

            if (model == null)
                throw new Exception(Exceptions.Ex0001);

            return model;
        }

        public bool Put(UserViewModel model)
        {
            User user = _userRepository.GetById(model.Id);

            if (user == null)
                throw new Exception(Exceptions.Ex0001);

          //user = _mapper.Map<User>(model) forma errada de realizar update com AutoMapper ja que dessa forma ele praticamente instacia um novo objeto e passa valores padrão para os objetos sem valores 
            user = _mapper.Map(model, user);

            return _userRepository.Put(user);
        }
        
        public bool Delete(string id)
        {
            User user = _userRepository.GetById(Guid.Parse(id));

            if (user == null)
                throw new Exception(Exceptions.Ex0001);

            return _userRepository.Delete(user);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel userRequest)
        {
            User user = _userRepository.Find(x => x.DeletionDate == null && x.Mail.ToLower() == userRequest.Mail.ToLower());

            if(user == null)
                throw new Exception(Exceptions.Ex0001);

            string token = TokenService.GenerateToken(user);

            UserViewModel model = _mapper.Map<UserViewModel>(user);

            return new UserAuthenticateResponseViewModel(model, token);
        }
    }
}
