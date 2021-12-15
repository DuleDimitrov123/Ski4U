using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntityWithId
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<T> Delete(T obj)
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async virtual Task<IList<T>> GetAll()
        {
            return await _dbSet.ToListAsync<T>();
        }

        public IList<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Include(includes[0]);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public T GetOneWithIncludes(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Include(includes[0]);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }

            return query.SingleOrDefault(e => e.Id == id);
        }

        public async virtual Task<T> GetOne(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
