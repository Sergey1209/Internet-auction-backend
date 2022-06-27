using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILotCategoryRepository : IRepository<LotCategory>
    {
        public Task<IEnumerable<LotCategory>> GetAllByDetalsAsync();
        public Task<LotCategory> GetByIdWithDetailsAsync(int id);
    }
}
