﻿using System.Collections.Generic;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TemplateContext context) : base(context)
        {

        }

        //removendo responsabilidade de buscar apenas os que estao com deletionDate null
        public IEnumerable<User> GetAll()
        {
            return Query(x => x.DeletionDate == null);
        }
    }
}
