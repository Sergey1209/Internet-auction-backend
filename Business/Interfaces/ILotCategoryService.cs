using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotCategoryService
    {
        /// <summary>
        /// Returns all entity
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LotCategoryModel>> GetAllAsync();

        /// <summary>
        /// Returns entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<LotCategoryModel> GetByIdAsync(int id);

        /// <summary>
        /// Adds new category.
        /// </summary>
        /// <param name="name">Category name</param>
        /// <param name="fileId">File id (image)</param>
        /// <returns></returns>
        public Task AddAsync(InputLotCategoryModel inputLotCategoryModel);

        /// <summary>
        /// Updates category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateAsyc(InputLotCategoryModel model);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteAsync(int id);

    }
}
