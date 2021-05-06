using app_agv_molis.Models;
using app_agv_molis.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace app_agv_molis.Helpers
{
    public class SqliteHelper<T> : IDatabase<T> where T : class, new()
    {
        private SQLiteAsyncConnection _database;

        public SqliteHelper()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3"));
            _database.CreateTableAsync<User>().Wait();
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return _database.Table<T>();
        }

        public async Task<int> Delete(T entity)
        {
            return await _database.DeleteAsync(entity);
        }

        public async Task<List<T>> Get()
        {
            return await _database.Table<T>().ToListAsync();
        }

        public async Task Delete(Expression<Func<T, bool>> predicate)
        {
            await _database.Table<T>().DeleteAsync(predicate);
        }

        public async Task<T> Get(int id)
        {
            return await _database.FindAsync<T>(id);
        }

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _database.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _database.FindAsync<T>(predicate);
        }

        public async Task<int> Insert(T entity)
        {
            return await _database.InsertAsync(entity);
        }

        public async Task<int> Update(T entity)
        {
            return await _database.UpdateAsync(entity);
        }
    }
}
