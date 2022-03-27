using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension//Extensão do context todas as configurações aqui podem ser chamadas no builder do templateContext ou em qualquer outro context
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)//O "this" faz com que ja receba o objeto que está chamando o metodo
        {
            builder.Entity<User>().HasData(new User { 
                UserId = Guid.Parse("0b214de7-8958-4956-8eed-28f9ba2c47c6"), 
                Name = "User Default",
                Mail = "userDefault@example.com"
            });

            return builder;
        }
    }
}
