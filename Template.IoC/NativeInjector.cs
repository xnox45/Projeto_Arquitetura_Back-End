using Microsoft.Extensions.DependencyInjection;
using Template.Application.Interface;
using Template.Application.Service;

namespace Template.IoC
{
    public static class NativeInjector
    {
        public static void RegisterService(IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();

        }
    }
}
