using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuctionService
    {
        public Task MakeBetAsync(int id, decimal betValue, int customerId);
        public Task<AuctionModel> GetByIdAsync(int lotId);
        public Task<AuctionModel> GetBetValueByIdAsync(int id);
    }
}
