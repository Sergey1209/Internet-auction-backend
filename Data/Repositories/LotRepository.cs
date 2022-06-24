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

        public async Task<IEnumerable<Lot>> GetIdAsync(Lot lot)
        {
            return await _dbSet
                .AsQueryable()
                .Where(x => x.Name == lot.Name)
                .Where(x => x.Description == lot.Description)
                .Where(x => x.InitialPrice == lot.InitialPrice)
                .Where(x => x.CategoryId == lot.CategoryId)
                .Where(x => x.Deadline == lot.Deadline)
                .Where(x => x.OwnerId == lot.OwnerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetAllByDetalsAsync()
        {
            return await _dbSet
                .AsQueryable()
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Receipt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetAllByDetalsByCategoryIdAsync(int categoryId)
        {
            var result = await _dbSet
                .AsQueryable()
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Receipt)
                .ToListAsync();

            return result;
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
                .AsQueryable()
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.LotImages).ThenInclude(x => x.File)
                .Include(x => x.Receipt)
                .FirstOrDefaultAsync();

            return result;
        }

        public void Update(Lot entity)
        {
            _proxyRepository.Update(entity);
        }
    }
}
