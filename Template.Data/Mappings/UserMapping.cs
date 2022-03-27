using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        //Configuração da tabela usuario
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);//Primary Key
            builder.Property(x => x.Name).IsRequired();//Not Null
            builder.Property(x => x.Name).HasMaxLength(40);//Not Null
        }
    }
}
