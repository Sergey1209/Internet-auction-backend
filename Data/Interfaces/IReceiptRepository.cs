using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Provides a mechanism for accessing the personal data of registered users
    /// </summary>
    public interface IAuctionRepository : IRepository<Auction>
    {
        /// <summary>
        /// Returns all entities with detals from the data source 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Auction>> GetAllWithDetailsAsync();
        /// <summary>
        /// Returns entity by id with detals from the data source 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Auction> GetByIdWithDetailsAsync(int id);
    }
}
