using System;
using System.Collections.Generic;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User> //Herdando metodos padrões do Repositorio
    {
        IEnumerable<User> GetAll();

        User GetById(Guid id);

        bool Put(User user);
    }
}
