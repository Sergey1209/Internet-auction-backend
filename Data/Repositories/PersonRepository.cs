using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AuthDbContext _dbContext;
        private readonly DbSet<Person> _dbSet;
        private readonly ProxyRepository<Person> _proxyRepository;

        public PersonRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.People;
            _proxyRepository = new ProxyRepository<Person>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task AddAsync(Person entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(Person entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public void Update(Person entity)
        {
            _proxyRepository.Update(entity);
        }
    }
}
