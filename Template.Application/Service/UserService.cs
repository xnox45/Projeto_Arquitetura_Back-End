using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            if (model.Id != Guid.Empty)
                throw new Exception(Exceptions.Ex0004);

            Validator.ValidateObject(model, new ValidationContext(model), true);

            User user = _mapper.Map<User>(model);

            _userRepository.Create(user);

            return true;
        }

        public UserViewModel GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || Guid.TryParse(id, out Guid guid))
                throw new Exception(Exceptions.Ex0003);

            UserViewModel model = _mapper.Map<UserViewModel>(_userRepository.GetById(Guid.Parse(id)));

            if (model == null)
                throw new Exception(Exceptions.Ex0001);

            return model;
        }

        public bool Put(UserViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Id.ToString()) || model.Id == new Guid())
                throw new Exception(Exceptions.Ex0003);

            User user = _userRepository.GetById(model.Id);

            if (user == null)
                throw new Exception(Exceptions.Ex0001);

          //user = _mapper.Map<User>(model) forma errada de realizar update com AutoMapper ja que dessa forma ele praticamente instacia um novo objeto e passa valores padrão para os objetos sem valores 
            user = _mapper.Map(model, user);

            return _userRepository.Put(user);
        }
        
        public bool Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || !Guid.TryParse(id, out Guid guid))
                throw new Exception("Id Empty");

            User user = _userRepository.GetById(Guid.Parse(id));

            if (user == null)
                throw new Exception(Exceptions.Ex0001);

            return _userRepository.Delete(user);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.Password) || string.IsNullOrWhiteSpace(userRequest.Mail))
                throw new Exception("Email/Password are requeried");

            User user = _userRepository.Find(x => x.DeletionDate == null && x.Mail.ToLower() == userRequest.Mail.ToLower());

            if(user == null)
                throw new Exception(Exceptions.Ex0001);

            string token = TokenService.GenerateToken(user);

            UserViewModel model = _mapper.Map<UserViewModel>(user);

            return new UserAuthenticateResponseViewModel(model, token);
        }
    }
}
