using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILotCategoryRepository : IRepository<LotCategory>
    {
        public Task<IEnumerable<LotCategory>> GetAllByDetalsAsync();
        public Task<LotCategory> GetByIdWithDetailsAsync(int id);
    }
}
