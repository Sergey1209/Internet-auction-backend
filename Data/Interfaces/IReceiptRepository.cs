using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAuctionRepository : IRepository<Auction>
    {
        public Task<IEnumerable<Auction>> GetAllWithDetailsAsync();
        public Task<Auction> GetByIdWithDetailsAsync(int id);
    }
}
