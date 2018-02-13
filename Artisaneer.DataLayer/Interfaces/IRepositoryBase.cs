using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        void Edit(T entity);
        T Find(string cid);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Save();
    }
}
