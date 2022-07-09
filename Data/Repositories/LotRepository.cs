using Data.Data;
using Data.Entities;
using Data.Extensions;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly InternetAuctionDbContext _dbContext;
        private readonly DbSet<Lot> _dbSet;
        private readonly ProxyRepository<Lot> _proxyRepository;

        public LotRepository(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.Lots;
            _proxyRepository = new ProxyRepository<Lot>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task AddAsync(Lot entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(Lot entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Lot>> GetAllByDetalsAsync()
        {
            return await _dbSet
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Auction)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetLastByDetalsAsync(int count)
        {
            return await _dbSet
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Auction)
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetRangeLotsByCategoryIdAsync(int categoryId, int lotId, int numberLots)
        {
            var now = DateTime.UtcNow;
            var result = await _dbSet
                .Where(x => x.CategoryId == categoryId || categoryId == 0)
                .OrderByDescending(x => x.Id)
                .Where(x => (lotId > 0 && x.Id < lotId) || lotId == 0)
                .Take(numberLots)
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Auction)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Lot>> GetRangeByDetalsAsync(int minId, int maxId)
        {
            if (minId > maxId)
            {
                (maxId, minId) = (minId, maxId);
            }

            var result = await _dbSet
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Auction)
                .Where(lot => lot.Id >= minId)
                .Where(lot => lot.Id < maxId)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Lot>> GetByFilterAsync(string searchString, int lotId, int numberLots)
        {
            return await _dbSet
                .OrderByDescending(x => x.Id)
                .Where(x => (lotId > 0 && x.Id < lotId) || lotId == 0)
                .Where(x => x.Name.Contains(searchString))
                .Take(numberLots)
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Auction)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<Lot> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public async Task<Lot> GetByIdWithDetailsAsync(int id)
        {
            var result = await _dbSet
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Auction)
                .FirstOrDefaultAsync();

            return result;
        }

        public void Update(Lot entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Lot entity");

            _dbContext.TruncateStringsBasedOnMaxLength(entity);

            var dbEntity = _dbSet.Find(entity.Id);

            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.CategoryId = entity.CategoryId;
            dbEntity.OwnerId = entity.OwnerId;

            _dbSet.Update(dbEntity);
        }


    }

}
