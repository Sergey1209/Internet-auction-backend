using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Provides a mechanism for accessing lots of auctions
    /// </summary>
    public interface ILotRepository : IRepository<Lot>
    {
        /// <summary>
        /// Returns all entities with detals from the data source 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetAllByDetalsAsync();

        /// <summary>
        /// Returns entity by id with detals from the data source 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Lot> GetByIdWithDetailsAsync(int id);
        
        /// <summary>
        /// Returns entity by id with detals from the data source 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetAllByFilterAsync(string searchString);

        /// <summary>
        /// Returns last lots
        /// </summary>
        /// <param name="count">Count lots</param>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetLastByDetalsAsync(int count);

        /// <summary>
        /// Returns range lots by id
        /// </summary>
        /// <param name="minId"></param>
        /// <param name="maxId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetRangeByDetalsAsync(int minId, int maxId);

    }
}
