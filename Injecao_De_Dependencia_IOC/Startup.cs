using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Template.Application.AutoMapper;
using Template.Data.Context;
using Template.IoC;

namespace Api.Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Busca no AppSentings Json no Banco TemplateDB
            string connectionStringTemplateDb = Configuration.GetConnectionString("TemplateDb");

            services.AddControllers();

            //Fazendo com que o banco utilize as configurações de outro projeto(Class Library)
            services.AddDbContext<TemplateContext>(opt => opt.UseSqlServer(connectionStringTemplateDb).EnableSensitiveDataLogging());

            //Faz com que a services entenda interfaces de outros projetos
            NativeInjector.RegisterService(services);

            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api.Project", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Injecao_De_Dependencia_IOC v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
