using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Provides a mechanism for accessing categories of lots
    /// </summary>
    public interface ILotCategoryRepository : IRepository<LotCategory>
    {
        /// <summary>
        /// Returns all entities with detals from the data source 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LotCategory>> GetAllByDetalsAsync();
        /// <summary>
        /// Returns entity by id with detals from the data source 
        /// </summary>
        /// <param name="id">id entity</param>
        /// <returns></returns>
        public Task<LotCategory> GetByIdWithDetailsAsync(int id);
    }
}
