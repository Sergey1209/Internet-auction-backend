using Data.Data;
using Data.Entities;
using Data.Extensions;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly InternetAuctionDbContext _dbContext;
        private readonly DbSet<File> _dbSet;
        private readonly ProxyRepository<File> _proxyRepository;

        public FileRepository(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.Files;
            _proxyRepository = new ProxyRepository<File>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            var result = await _dbSet.AsQueryable().FirstOrDefaultAsync(x => x.Name == name);
            return result?.Id ?? throw new InvalidOperationException();
        }

        public async Task AddAsync(File entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(File entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<File>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<File> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public void Update(File entity)
        {
            _proxyRepository.Update(entity);
        }
    }
}
