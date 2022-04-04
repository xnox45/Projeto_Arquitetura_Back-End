using System.Collections.Generic;
using Template.Application.ViewModel;

namespace Template.Application.Interface
{
    public interface IUserService
    {
        List<UserViewModel> Get();

        bool Post(UserViewModel model);

        public UserViewModel GetById(string id);

        public bool Put(UserViewModel model);
    }
}
