using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotCategoryService : ICrud<LotCategoryModel>
    {
        /// <summary>
        /// Adds new category.
        /// </summary>
        /// <param name="name">Category name</param>
        /// <param name="fileId">File id (image)</param>
        /// <returns></returns>
        public Task AddAsync(string name, int? fileId);

        /// <summary>
        /// Updates category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateAsyc(InputLotCategoryModel model);

        /// <summary>
        /// Returns file id by category id
        /// </summary>
        /// <param name="lotCategoryId"></param>
        /// <returns></returns>
        public Task<int> GetFileId(int lotCategoryId);
    }
}
