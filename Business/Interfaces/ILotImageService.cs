using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotImageService
    {
        /// <summary>
        /// Adds new lotimage
        /// </summary>
        /// <param name="lotId">Lot id</param>
        /// <param name="images">Images</param>
        /// <returns></returns>
        public Task AddAsync(int lotId, IEnumerable<IFormFile> images);

        /// <summary>
        /// Returns lotimage by lot id
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public Task<IEnumerable<LotImageModel>> GetByLotIdAsync(int lotId);

        /// <summary>
        /// Deletes lotimages. 
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public Task DeleteByLotIdAsync(int lotId);

    }
}
