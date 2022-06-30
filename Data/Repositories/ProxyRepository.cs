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

        /// <summary>
        /// Provides a proxy mechanism for working with a data source
        /// </summary>
        /// <param name="dbContext">Represents the data source context.</param>
        /// <param name="dbSet">Represents a dbSet object of a data source</param>
        public ProxyRepository(DbContext dbContext, DbSet<TEntity> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        /// <summary>
        /// Adds an entity to the data source
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            Validate(entity);
            entity.Id = 0;
            _dbContext.TruncateStringsBasedOnMaxLength(entity);
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Removes an entity from the data source
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            Validate(entity);

            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Removes an entity by id from the data source
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return;

            Delete(entity);
        }

        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        /// <summary>
        /// Returns entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Updates entity in the data source
        /// </summary>
        /// <param name="entity"></param>
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
