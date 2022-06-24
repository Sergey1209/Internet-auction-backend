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
    public class LotCategoryRepository : ILotCategoryRepository
    {
        private readonly InternetAuctionDbContext _dbContext;
        private readonly DbSet<LotCategory> _dbSet;
        private readonly ProxyRepository<LotCategory> _proxyRepository;

        public LotCategoryRepository(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.LotCategories;
            _proxyRepository = new ProxyRepository<LotCategory>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task AddAsync(LotCategory entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(LotCategory entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<LotCategory>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<IEnumerable<LotCategory>> GetAllByDetalsAsync()
        {
            var res = await _dbSet
                .Include(x => x.File)
                .ToListAsync();
            return res;
        }

        public async Task<LotCategory> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public async Task<LotCategory> GetByIdWithDetailsAsync(int id)
        {
            var res = await _dbSet
                .AsQueryable()
                .Where (x => x.Id == id)
                .Include(x => x.File)
                .Include(x => x.Lots)
                .FirstAsync();

            return res;
        }

        public void Update(LotCategory entity)
        {
            _proxyRepository.Update(entity);
        }
    }
}
