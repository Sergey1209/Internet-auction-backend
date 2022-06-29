using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotService
    {
        public Task<IEnumerable<LotModel>> GetAllAsync();
        public Task<IEnumerable<LotModel>> GetAllByCategoryIdAsync(int categoryId);
        public Task<LotModel> GetByIdAsync(int modelId);
        public Task AddAsync(InputLotModel inputModel);
        public Task UpdateAsyc(InputLotModel model);
        public Task DeleteAsync(int modelId);
        public Task<IEnumerable<LotModel>> GetAllByFilter(string searchString);
    }
}
