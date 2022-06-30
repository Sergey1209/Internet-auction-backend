using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotService
    {
        /// <summary>
        /// Returns all lots
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetAllAsync();

        /// <summary>
        /// Returns all lots by category ID.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetAllByCategoryIdAsync(int categoryId);

        /// <summary>
        /// Returns lot by ID
        /// </summary>
        /// <param name="id">Lot ID</param>
        /// <returns></returns>
        public Task<LotModel> GetByIdAsync(int id);

        /// <summary>
        /// Adds new lot
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public Task AddAsync(InputLotModel inputModel);

        /// <summary>
        /// Updates lot
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateAsyc(InputLotModel model);

        /// <summary>
        /// Deletes lot by ID
        /// </summary>
        /// <param name="id">Lot ID</param>
        /// <returns></returns>
        public Task DeleteAsync(int id);

        /// <summary>
        /// Returns all lots by the filter string in the description
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetAllByFilter(string searchString);
    }
}
