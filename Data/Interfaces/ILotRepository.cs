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
        /// <param name="categoryId"></param>
        /// <param name="lotId">ID below which the selection will be performed</param>
        /// <param name="numberLots">Number of lots to be returned</param>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetRangeLotsByCategoryIdAsync(int categoryId, int lotId, int numberLots);

        /// <summary>
        /// Returns entity by id with detals from the data source 
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="lotId">ID below which the selection will be performed</param>
        /// <param name="numberLots">Number of lots to be returned</param>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetByFilterAsync(string searchString, int lotId, int numberLots);

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
