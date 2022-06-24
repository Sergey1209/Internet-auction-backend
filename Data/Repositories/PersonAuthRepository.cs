using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Repositories
{
    public class PersonAuthRepository : IPersonAuthRepository
    {
        private readonly AuthDbContext _dbContext;
        private readonly DbSet<PersonAuth> _dbSet;

        public PersonAuthRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.PeopleAuths;
        }

        public async Task AddAsync(PersonAuth entity)
        {
            Validate(entity);
            await _dbSet.AddAsync(entity);
        }

        public void Delete(PersonAuth entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public async Task DeleteByIdAsync(int personId)
        {
            var entity = await _dbSet.FindAsync(personId);
            if (entity == null)
                return;

            Delete(entity);
        }

        public async Task DeleteByLoginAsync(string login)
        {
            var entity = 
                await _dbSet.SingleOrDefaultAsync(x => x.Email == login);

            if (entity == null)
                return;

            Delete(entity);
        }

        public async Task<IEnumerable<PersonAuth>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<PersonAuth> GetByIdAsync(int personId)
        {
            return await _dbSet.FindAsync(personId);
        }

        public async Task<PersonAuth> GetByLoginAsync(string login)
        {
            return await _dbSet
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Email == login);
        }

        public void Update(PersonAuth entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var currentEntity = _dbSet
                .AsQueryable()
                .SingleOrDefault(x => x.PersonId == entity.PersonId);

            currentEntity.Email = entity.Email;
            currentEntity.Password = entity.Password;

            _dbSet.Update(currentEntity);
        }

        private void Validate(PersonAuth entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
        }
    }
}
