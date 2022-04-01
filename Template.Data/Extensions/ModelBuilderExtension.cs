using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using Template.Domain.Entities;
using Template.Domain.Models;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension//Extensão do context todas as configurações aqui podem ser chamadas no builder do templateContext ou em qualquer outro context
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)//O "this" faz com que ja receba o objeto que está chamando o metodo
        {
            builder.Entity<User>().HasData(new User { 
                Id = Guid.Parse("0b214de7-8958-4956-8eed-28f9ba2c47c6"), 
                Name = "User Default",
                Mail = "userDefault@example.com",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            });

            return builder;
        }

        public static ModelBuilder ConfigureGlobalApplication(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;

                        case nameof(Entity.CreationDate):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;

                        case nameof(Entity.UpdateDate):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        
                        case nameof(Entity.DeletionDate):
                            property.IsNullable = true;
                            property.SetDefaultValue(null);
                            break;

                        default:
                            break;
                    }
                }
            }

            return builder;
        }
    }
}
