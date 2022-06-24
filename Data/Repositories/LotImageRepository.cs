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
    public class LotImageRepository : ILotImageRepository
    {
        private readonly InternetAuctionDbContext _dbContext;
        private readonly DbSet<LotImage> _dbSet;
        private readonly ProxyRepository<LotImage> _proxyRepository;

        public LotImageRepository(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.LotImages;
            _proxyRepository = new ProxyRepository<LotImage>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task AddAsync(LotImage entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(LotImage entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public void DeleteAsync(IEnumerable<LotImage> lotImages)
        {
            _dbSet.RemoveRange(lotImages);
        }

        public async Task<IEnumerable<LotImage>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<IEnumerable<LotImage>> GetAllByDetalsAsync()
        {
            return await _dbSet
                .Include(x => x.File)
                .Include(x => x.Lot)
                .ToListAsync();
        }

        public async Task<LotImage> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public async Task<LotImage> GetByIdDetalsAsync(int id)
        {
            var res = await _dbSet
                .AsQueryable()
                .Where(x => x.Id == id)
                .Include(x => x.Lot)
                .Include(x=> x.File)
                .FirstOrDefaultAsync();

            return res;
        }

        public async Task<IEnumerable<LotImage>> GetByLotIdAsync(int lotId)
        {
            var res = await _dbSet
                .AsQueryable()
                .Where(x => x.LotId == lotId)
                .ToListAsync();

            return res;
        }

        public void Update(LotImage entity)
        {
            _proxyRepository.Update(entity);
        }
    }
}
