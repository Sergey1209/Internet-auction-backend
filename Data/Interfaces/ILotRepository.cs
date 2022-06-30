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
        /// Returns all entities from the data source for a category
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Lot>> GetAllByDetalsByCategoryIdAsync(int categoryId);
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
    }
}
