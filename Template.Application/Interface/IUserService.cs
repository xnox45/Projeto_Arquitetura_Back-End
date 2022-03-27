using System.Collections.Generic;
using Template.Application.ViewModel;

namespace Template.Application.Interface
{
    public interface IUserService
    {
        List<UserViewModel> Get();
    }
}
