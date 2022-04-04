using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModel;
using Template.Domain.Entities;

namespace Template.Application.AutoMapper
{
    public class AutoMapperSetup : Profile //É preciso criar uma classe de setup para que possamos informar qual classe vai passar pra qual e chama-la no startup
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, User>();

            #endregion

            #region DomainToViewModel

            CreateMap<User, UserViewModel>();

            #endregion
        }
    }
}
