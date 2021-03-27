
using BTMovie.Core.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTMovie.DataAccess.GenericRepository
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
       
        T Add(T entity);
        bool Update(T entity);

        bool Remove(T entity);
        //bool RemoveById(int id);
        //bool RemoveRange(IEnumerable<T> entity);
        IEnumerable<T> Where(Expression<Func<T, bool>> where);
        T Get(int id);
        IEnumerable<T> All();

        //T Get(string name,string lastname,string tckn);

        //Task<T> GetAsync(Expression<Func<T, bool>> filter);

        //T Get(Expression<Func<T, bool>> filter);

        //Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);

        //List<T> Getlist(Expression<Func<T, bool>> filter = null);

        //T Find(int id);
        //Task<bool> AddAsync(T entity);

        //bool AddRange(IEnumerable<T> entity);

        //bool UpdateRange(IEnumerable<T> entity);

        //Task<T> UpdateAsync(T entity);
        //int ExecuteSqlRaw(string query);
        //Task<int> ExecuteSqlRawAsync(string query);

        //IQueryable<T> FromSql(string query);

        //string GetSingleValue(string query, string fieldName);
        //List<string> GetMultiValues(string query, string fieldName);

        //IEnumerable<T> All();
        //IEnumerable<T> Where(Expression<Func<T, bool>> where);
        //T FirstOrDefault(Expression<Func<T, bool>> where);
        //bool Any(Expression<Func<T, bool>> where);
        // IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
    }
}
