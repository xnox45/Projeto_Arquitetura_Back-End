using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Interfaces;
using Template.Domain.Models;

namespace Template.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly TemplateContext _context;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public Repository(TemplateContext context)
        {
            _context = context;
        }
   
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)//(Expression<Func<TEntity, bool>>)Faz com que para chamar o metodo tenha que usar uma Expressão Lambda
        {
            try
            {
                return DbSet.Where(where);
            }
            catch
            {
                throw;
            }
        }


        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
