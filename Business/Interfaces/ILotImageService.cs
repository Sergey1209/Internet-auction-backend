using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotImageService
    {
        public Task AddAsync(int lotId, IEnumerable<IFormFile> images);
        public Task<IEnumerable<LotImageModel>> GetByLotIdAsync(int lotId);
        public Task DeleteByLotIdAsync(int lotId);

    }
}
