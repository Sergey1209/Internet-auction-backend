using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Data.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly InternetAuctionDbContext _dbContext;
        private readonly DbSet<Auction> _dbSet;
        private readonly ProxyRepository<Auction> _proxyRepository;

        public AuctionRepository(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.Auctions;
            _proxyRepository = new ProxyRepository<Auction>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task AddAsync(Auction entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(Auction entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Auction>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<Auction> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public void Update(Auction entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var dbEntity = _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id).Result;

            var now = DateTime.UtcNow;
            if (now < dbEntity.Deadline && entity.BetValue > dbEntity.BetValue)
            {
                dbEntity.BetValue = entity.BetValue;
                dbEntity.OperationDate = now;
                dbEntity.CustomerId = entity.CustomerId;
                _dbSet.Update(dbEntity);
            }
            else
                throw new AuctionUpdateException("Bet is invalid");
        }

        public async Task<IEnumerable<Auction>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(x => x.Lot)
                .ThenInclude(x => x.LotImages)
                .ThenInclude(x => x.File)
                .ToListAsync();
        }

        public async Task<Auction> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Lot)
                .ThenInclude(x => x.LotImages)
                .ThenInclude(x => x.File)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
