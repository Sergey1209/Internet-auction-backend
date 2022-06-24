using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotService
    {
        public Task<IEnumerable<LotModel>> GetAllAsync();
        public Task<IEnumerable<LotModel>> GetAllByCategoryIdAsync(int categoryId);
        public Task<LotModel> GetByIdAsync(int modelId);
        public Task<int> AddAsync(InputLotModel model);
        public Task UpdateAsyc(InputLotModel model);
        public Task DeleteAsync(int modelId);

    }
}
