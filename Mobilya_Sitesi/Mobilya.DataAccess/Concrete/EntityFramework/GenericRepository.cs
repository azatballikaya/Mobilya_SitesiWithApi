using Microsoft.EntityFrameworkCore.Query;
using Mobilya.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context=context;
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null, Func<IQueryable<T>,IIncludableQueryable<T,object>>include=null)
        {
            IQueryable<T> query=_context.Set<T>();
            if (include != null)
            {
                query = include(query);
            }
            if (filter != null)
            {
                query=query.Where(filter);
            }
            return query.ToList();
        }
        public T Get(Expression<Func<T, bool>> filter , Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            
            IQueryable<T> query=_context.Set<T>();
            if(include != null)
            {
                query = include(query);
            }
            if(filter != null)
            {
                query=query.Where(filter);
            }
            return query.FirstOrDefault();



        }
        public T GetById(int id)
        {
            
            return _context.Set<T>().Find(id);

        }

        public T Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

    
    }
}
