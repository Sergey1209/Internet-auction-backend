﻿using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILotRepository : IRepository<Lot>
    {
        public Task<IEnumerable<Lot>> GetAllByDetalsAsync();
        public Task<IEnumerable<Lot>> GetAllByDetalsByCategoryIdAsync(int categoryId);
        public Task<Lot> GetByIdWithDetailsAsync(int id);
        public Task<IEnumerable<Lot>> GetAllByFilterAsync(string searchString);
    }
}
