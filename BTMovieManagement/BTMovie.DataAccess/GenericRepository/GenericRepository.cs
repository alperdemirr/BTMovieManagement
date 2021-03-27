
using BTMovie.Core.Constants;
using BTMovie.Core.Entity;
using BTMovie.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTMovie.DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T>
      where T : class, IEntity, new()
    {

        private readonly BTMovieContext _dbContext;
        public GenericRepository(BTMovieContext dbContext)
        {
            this._dbContext = dbContext;
         
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where);
        }
        public IEnumerable<T> All()
        {
            return _dbContext.Set<T>().ToList();
        }

        public bool Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return true;
        }


        public bool Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        //   public bool RemoveById(int id)
        //   {

        //       var entity = _dbContext.Set<T>().Find(id);

        //       _dbContext.Set<T>().Remove(entity);
        //       _dbContext.SaveChanges();

        //      //var entity = (TEntity)Activator.CreateInstance(typeof(TEntity));

        //       ////entity.GetType().GetProperty("Id").SetValue(entity, id);

        //       //var tableProp = _dbContext.GetType().GetProperties().FirstOrDefault(q => q.PropertyType == typeof(DbSet<TEntity>));

        //       //var tableName = tableProp.Name;

        //       //string query = $"DELETE FROM [dbo].[{tableName}] WHERE [Id]={id}";
        //       //var rows = _dbContext.Database.ExecuteSqlRaw(query);

        //       return true;
        //   }

        //   public bool RemoveRange(IEnumerable<T> entities)
        //   {
        //       _dbContext.Set<T>().RemoveRange(entities);
        //       _dbContext.SaveChanges();
        //       return true;
        //   }

        //   public bool AddRange(IEnumerable<T> entity)
        //   {
        //       _dbContext.Set<T>().AddRange(entity);
        //       _dbContext.SaveChanges();
        //       return true;
        //   }


        //   public T Find(int id)
        //   {
        //       return _dbContext.Set<T>().Find(id);
        //   }

        //   public async Task<bool> AddAsync(T entity)
        //   {

        //       await _dbContext.Set<T>().AddAsync(entity);
        //       _dbContext.SaveChanges();
        //       return true;
        //   }

        //   public int ExecuteSqlRaw(string query)
        //   {
        //       return _dbContext.Database.ExecuteSqlRaw(query);
        //   }

        //   public async Task<int> ExecuteSqlRawAsync(string query)
        //   {
        //       return await _dbContext.Database.ExecuteSqlRawAsync(query);
        //   }

        //   public IQueryable<T> FromSql(string query)
        //   {
        //       return _dbContext.Set<T>().FromSqlRaw<T>(query);
        //   }

        //   public string GetSingleValue(string query, string fieldName)
        //   {
        //       var connection = _dbContext.Database.GetDbConnection() as SqlConnection;
        //       if (connection.State == System.Data.ConnectionState.Closed) { connection.Open(); }

        //       SqlCommand cmd = new SqlCommand(query, connection);
        //       var result = cmd.ExecuteScalar()?.ToString();
        //       //var result = .FromSql(query).AsEnumerable().Select(q => new { Field = q.GetType().GetField(fieldName).GetValue(null) }).FirstOrDefault().Field as string;

        //       cmd.Dispose();
        //       connection.Close();

        //       return result;
        //   }

        //   public List<string> GetMultiValues(string query, string fieldName)
        //   {
        //       var connection = _dbContext.Database.GetDbConnection() as SqlConnection;
        //       if (connection.State == System.Data.ConnectionState.Closed) { connection.Open(); }

        //       SqlCommand cmd = new SqlCommand(query, connection);
        //       var dr = cmd.ExecuteReader();

        //       var valuesList = new List<string>();
        //       while (dr.Read())
        //       {
        //           var value = dr[fieldName]?.ToString();

        //           if (!string.IsNullOrEmpty(value)) { valuesList.Add(value); }
        //       }

        //       cmd.Dispose();
        //       connection.Close();

        //       return valuesList;
        //   }

        //   public List<dynamic> ExecuteSqlRawAndGetResults(string query)
        //   {
        //       var connection = _dbContext.Database.GetDbConnection() as SqlConnection;
        //       if (connection.State == System.Data.ConnectionState.Closed) { connection.Open(); }

        //       SqlCommand cmd = new SqlCommand(query, connection);
        //       var dr = cmd.ExecuteReader();

        //       var resultsList = new List<dynamic>();
        //       while (dr.Read())
        //       {
        //           var dynamicClass = Activator.CreateInstance<dynamic>();
        //           foreach (var columnItem in dr.GetColumnSchema())
        //           {
        //               var field = dynamicClass.GetType().GetField(columnItem.ColumnName);
        //               if (field != null) { field.SetValue(field, dr[columnItem.ColumnName]); }
        //           }

        //           resultsList.Add(dynamicClass);
        //       }

        //       cmd.Dispose();
        //       connection.Close();

        //       return resultsList;
        //   }



        //   public IEnumerable<T> Where(Expression<Func<T, bool>> where)
        //   {
        //       return _dbContext.Set<T>().Where(where);
        //   }

        //   public T FirstOrDefault(Expression<Func<T, bool>> where)
        //   {
        //       return _dbContext.Set<T>().FirstOrDefault(where);
        //   }

        //   public bool Any(Expression<Func<T, bool>> where)
        //   {
        //       return _dbContext.Set<T>().Any(where);
        //   }

        ///*   public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        //   {
        //       if (isDesc)
        //           return _dbContext.Set<T>().OrderByDescending(orderBy);
        //       return _dbContext.Set<T>().OrderBy(orderBy);
        //   }
        //*/

        //   private bool Save()
        //   {
        //       _dbContext.SaveChanges();
        //       return true;
        //   }

        //   private async Task<bool> SaveAsync()
        //   {
        //       await _dbContext.SaveChangesAsync();
        //       return true;
        //   }

        //   public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        //   {
        //       if (filter == null)
        //       {
        //           return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
        //       }
        //       else
        //       {
        //           return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
        //       }
        //   }

        //   public T Get(Expression<Func<T, bool>> filter)
        //   {
        //       return _dbContext.Set<T>().FirstOrDefault(filter);
        //   }

        //   public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null)
        //   {
        //       if (filter != null)
        //       {
        //           return await _dbContext.Set<T>().Where(filter).ToListAsync();
        //       }
        //       else
        //       {
        //           return await _dbContext.Set<T>().ToListAsync();
        //       }
        //   }

        //   public List<T> Getlist(Expression<Func<T, bool>> filter = null)
        //   {
        //       if (filter != null)
        //       {
        //           return _dbContext.Set<T>().Where(filter).ToList();
        //       }
        //       else
        //       {
        //           return _dbContext.Set<T>().ToList();
        //       }
        //   }

        //   public async Task<T> UpdateAsync(T entity)
        //   {
        //       _dbContext.Set<T>().Update(entity);
        //       await _dbContext.SaveChangesAsync();
        //       return entity;
        //   }

        //   public bool UpdateRange(IEnumerable<T> entity)
        //   {
        //       _dbContext.Set<T>().UpdateRange(entity);
        //       return _dbContext.SaveChanges()>0;

        //   }

        //   public T Get(string name, string lastname, string tckn)
        //   {
        //       return _dbContext.Set<T>().Find(name,lastname,tckn);

        //   }
    }
}
