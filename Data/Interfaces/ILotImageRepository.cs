using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Provides a mechanism for accessing images of lots
    /// </summary>
    public interface ILotImageRepository : IRepository<LotImage>
    {
        /// <summary>
        /// Returns all entities with detals from the data source 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LotImage>> GetAllByDetalsAsync();
        /// <summary>
        /// Returns entity by id with detals from the data source 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<LotImage> GetByIdDetalsAsync(int id);
        /// <summary>
        /// Returns all entity by lot's id
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public Task<IEnumerable<LotImage>> GetByLotIdAsync(int lotId);
        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="lotImages"></param>
        public void DeleteAsync(IEnumerable<LotImage> lotImages);
    }
}
