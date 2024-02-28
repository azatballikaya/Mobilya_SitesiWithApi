using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        T GetById(int id);
        T Get(Expression<Func<T, bool>> filter , Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        List<T> GetAll(Expression<Func<T, bool>> filter=null,Func<IQueryable<T>,IIncludableQueryable<T,object>> include=null);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
