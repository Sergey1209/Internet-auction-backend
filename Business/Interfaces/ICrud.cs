using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        public Task<IEnumerable<TModel>> GetAllAsync();
        public Task<TModel> GetByIdAsync(int modelId);
        public Task AddAsync(TModel model);
        public Task DeleteAsync(int modelId);
        public Task UpdateAsyc(TModel model);   
    }
}
