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
        private IReceiptRepository _receiptRepository;
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

        public IReceiptRepository ReceiptRepository
        {
            get
            {
                if (_receiptRepository == null)
                    _receiptRepository = new ReceiptRepository(_dbContext);

                return _receiptRepository;
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
