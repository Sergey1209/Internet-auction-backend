using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        ILotCategoryRepository LotCategoryRepository { get; }
        ILotRepository LotRepository { get; }
        IReceiptRepository ReceiptRepository { get; }
        IFileRepository FileRepository { get; }
        ILotImageRepository LotImageRepository { get; }
        public Task SaveAsync();
    }
}
