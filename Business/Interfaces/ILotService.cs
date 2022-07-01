﻿using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotService
    {
        /// <summary>
        /// Returns all lots
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetAllAsync();

        /// <summary>
        /// Returns last lots
        /// </summary>
        /// <param name="count">Lots count</param>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetLastAsync(int count);

        /// <summary>
        /// Returns range lots
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetRangeAsync(int id1, int id2);

        /// <summary>
        /// Returns lot by ID
        /// </summary>
        /// <param name="id">Lot ID</param>
        /// <returns></returns>
        public Task<LotModel> GetByIdAsync(int id);

        /// <summary>
        /// Adds new lot
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public Task AddAsync(InputLotModel inputModel);

        /// <summary>
        /// Updates lot
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateAsyc(InputLotModel model);

        /// <summary>
        /// Deletes lot by ID
        /// </summary>
        /// <param name="id">Lot ID</param>
        /// <returns></returns>
        public Task DeleteAsync(int id);

        /// <summary>
        /// Returns all lots by the filter string in the description
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Task<IEnumerable<LotModel>> GetAllByFilter(string searchString);
    }
}
