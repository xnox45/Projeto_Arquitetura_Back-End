using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;
using Template.Application.AutoMapper;
using Template.Auth.Models;
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

            //chamando configurações do automapper
            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Api.Project", 
                    Version = "v1" ,
                    Description = "Projeto de arquitetura Back-End e Angular no front-End",
                    Contact = new OpenApiContact{
                        Name = "Frederick Aquino",
                        Email = "xnox.45@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/frederick-aquino-2913971a0")
                    }
                });

                string xmlPath = Path.Combine("Extras", "API_Doc.xml");
                c.IncludeXmlComments(xmlPath);
            });

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
