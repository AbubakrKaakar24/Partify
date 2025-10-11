using Microsoft.EntityFrameworkCore;
using Partify.Domain.RespositoryContracts.Base;
using Partify.Infrastructure.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Infrastructure.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PortifyDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(PortifyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public  Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, string? includeProperties = null, bool tracked = true)
        {
            
            IQueryable<T> query;
            if (tracked)
            {
                query = _dbSet;
            }
            else
            {
                query = _dbSet.AsNoTracking();
            }
            query = query.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefaultAsync()!;
        }
    }
}
