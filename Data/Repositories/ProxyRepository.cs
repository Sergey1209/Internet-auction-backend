using Data.Entities;
using Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProxyRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public ProxyRepository(DbContext dbContext, DbSet<TEntity> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public async Task AddAsync(TEntity entity)
        {
            Validate(entity);
            entity.Id = 0;
            _dbContext.TruncateStringsBasedOnMaxLength(entity);
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Validate(entity);

            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);

            var sdas2 = _dbContext.Entry(entity).State;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return;

            Delete(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Validate(entity);
            _dbSet.Update(entity);
        }

        private void Validate(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
        }

    }
}
