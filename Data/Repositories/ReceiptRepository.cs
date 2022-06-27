using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly InternetAuctionDbContext _dbContext;
        private readonly DbSet<Receipt> _dbSet;
        private readonly ProxyRepository<Receipt> _proxyRepository;

        public ReceiptRepository(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _dbSet = dbContext.Receipts;
            _proxyRepository = new ProxyRepository<Receipt>(dbContext: _dbContext, dbSet: _dbSet);
        }

        public async Task AddAsync(Receipt entity)
        {
            await _proxyRepository.AddAsync(entity: entity);
        }

        public void Delete(Receipt entity)
        {
            _proxyRepository.Delete(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _proxyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _proxyRepository.GetAllAsync();
        }

        public async Task<Receipt> GetByIdAsync(int id)
        {
            return await _proxyRepository.GetByIdAsync(id);
        }

        public void Update(Receipt entity)
        {
            _proxyRepository.Update(entity);
        }

        public async Task<IEnumerable<Receipt>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(x => x.Lot)
                .ToListAsync();
        }

        public async Task<Receipt> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .AsQueryable()
                .Include(x => x.Lot)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
