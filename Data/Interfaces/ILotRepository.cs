using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILotRepository : IRepository<Lot>
    {
        public Task<IEnumerable<Lot>> GetAllByDetalsAsync();
        public Task<IEnumerable<Lot>> GetAllByDetalsByCategoryIdAsync(int categoryId);
        public Task<IEnumerable<Lot>> GetIdAsync(Lot lot);
        public Task<Lot> GetByIdWithDetailsAsync(int id);
    }
}
