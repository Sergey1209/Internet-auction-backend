using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        /// <summary>
        /// Returns all entity
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        /// Returns entity by id
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public Task<TModel> GetByIdAsync(int modelId);

        /// <summary>
        /// Adds new entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task AddAsync(TModel model);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public Task DeleteAsync(int modelId);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateAsyc(TModel model);
    }
}
