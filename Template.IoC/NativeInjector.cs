using Microsoft.Extensions.DependencyInjection;
using Template.Application.Interface;
using Template.Application.Service;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Template.IoC
{
    public static class NativeInjector
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region Services
            
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repository

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
