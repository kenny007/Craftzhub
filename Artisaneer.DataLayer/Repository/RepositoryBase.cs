using Artisaneer.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer.Repository
{

    public abstract class RepositoryBase<C, T> : IRepositoryBase<T>  where T : class
      where C : DbContext, new()
    {
        public C _entities = new C();
        protected C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public T Find(string cid)
        {
            return _entities.Set<T>().Find(cid);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
           IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Insert(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
        //Not that good to have this in the Repository as this will change per Model class
        //public IQueryable<T> FindById(string id)
        //{
        //    return _entities.Set<T>().Find(id);
        //}
        public virtual void Save()
        {
            _entities.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
                if (disposing)
                    _entities.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}

