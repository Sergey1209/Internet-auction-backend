using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Provides repository of categories 
        /// </summary>
        ILotCategoryRepository LotCategoryRepository { get; }
        /// <summary>
        /// Provides repository of lots 
        /// </summary>
        ILotRepository LotRepository { get; }
        /// <summary>
        /// Provides repository of auctions 
        /// </summary>
        IAuctionRepository AuctionRepository { get; }
        /// <summary>
        /// Provides repository of files 
        /// </summary>
        IFileRepository FileRepository { get; }
        /// <summary>
        /// Provides a repository of lot images
        /// </summary>
        ILotImageRepository LotImageRepository { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync();
    }
}
