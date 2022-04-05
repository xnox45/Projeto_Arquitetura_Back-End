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
                return DbSet.AsNoTracking().Where(where);
            }
            catch
            {
                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)//(Expression<Func<TEntity, bool>>)Faz com que para chamar o metodo tenha que usar uma Expressão Lambda
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);//O AsNoTracking tbm serve para que possamos atualizar um dado
            }
            catch
            {
                throw;
            }
        }

        public TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);

            Save();

            return entity;
        }

        public bool Update(TEntity model)
        {
            try
            {
                if (model is Entity)
                {
                    (model as Entity).UpdateDate = DateTime.Now;
                }

                var entry = _context.Entry(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Delete(TEntity model)
        {
            try
            {
                if (model is Entity)
                {
                    (model as Entity).DeletionDate = DateTime.Now;
                    var _entry = _context.Entry(model);

                    DbSet.Attach(model);

                    _entry.State = EntityState.Modified;
                }
                else
                {
                    var _entry = _context.Entry(model);
                    DbSet.Attach(model);
                    _entry.State = EntityState.Deleted;
                }

                return Save() > 0;
            }
            catch (Exception)
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
