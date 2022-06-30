using Data.Data;
using Data.Interfaces;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InternetAuctionDbContext _dbContext;
        private ILotCategoryRepository _lotCategoryRepository;
        private ILotRepository _lotRepository;
        private IAuctionRepository _auctionRepository;
        private IFileRepository _imageRepository;
        private ILotImageRepository _lotImagesRepository;

        public UnitOfWork(InternetAuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ILotCategoryRepository LotCategoryRepository
        {
            get
            {
                if (_lotCategoryRepository == null)
                    _lotCategoryRepository = new LotCategoryRepository(_dbContext);

                return _lotCategoryRepository;
            }
        }

        public ILotRepository LotRepository
        {
            get
            {
                if (_lotRepository == null)
                    _lotRepository = new LotRepository(_dbContext);

                return _lotRepository;
            }
        }

        public IAuctionRepository AuctionRepository
        {
            get
            {
                if (_auctionRepository == null)
                    _auctionRepository = new AuctionRepository(_dbContext);

                return _auctionRepository;
            }
        }


        public IFileRepository FileRepository
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new FileRepository(_dbContext);

                return _imageRepository;
            }
        }

        public ILotImageRepository LotImageRepository
        {
            get
            {
                if (_lotImagesRepository == null)
                    _lotImagesRepository = new LotImageRepository(_dbContext);

                return _lotImagesRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
