using AppNet.Domain.Base;
using AppNet.EFramework;
using AppNet.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> entityObject;
        public BaseRepository(AppDbContext _context)
        {
            context = _context;
            entityObject = context.Set<T>();
        }
        public bool Activate(T entity)
        {
            return Activate(entity.Id);
        }

        public bool Activate(int Id)
        {
            var entity = Get(Id);
            entity.Status = true;
            return SaveChanges();
        }

        public T Create(T entity)
        {
            entityObject.Add(entity);
            SaveChanges();
            return entity;
        }

        public bool Deactivate(T entity)
        {
            return Deactivate(entity.Id);
        }

        public bool Deactivate(int Id)
        {
            var entity = Get(Id);
            entity.Status = false;
            return SaveChanges();
        }

        public bool Delete(T entity)
        {
            return Delete(entity.Id);
        }

        public bool Delete(int Id)
        {
            //entityObject.FirstOrDefault(t => t.Id == Id);
            entityObject.Remove(Get(Id));
            return SaveChanges();
        }

        public T Get(int Id)
        {
            return entityObject.FirstOrDefault(t => t.Id == Id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null) return entityObject;
            return entityObject.Where(predicate);
        }

        public bool SaveChanges()
        {
            try
            {



                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(T entity)
        {
            //if (context.Entry(entity).State == EntityState.Detached)
            //{
            //    entityObject.Attach(entity);
            //}

            //if (entity is ICreatable)
            //{
            //    var e = (ICreatable)entity;
            //    e.CreateOn = DateTime.Now;
            //}
            //if (entity is IModifiable)
            //{
            //    var e = (IModifiable)entity;
            //    e.ModifyOn = DateTime.Now;
            //}

            context.Set<T>().AddOrUpdate(entity);
            return SaveChanges();
        }
    }
}
