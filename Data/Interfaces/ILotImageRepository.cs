using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILotImageRepository : IRepository<LotImage>
    {
        public Task<IEnumerable<LotImage>> GetAllByDetalsAsync();
        public Task<LotImage> GetByIdDetalsAsync(int id);
        public Task<IEnumerable<LotImage>> GetByLotIdAsync(int lotId);
        public void DeleteAsync(IEnumerable<LotImage> lotImages);
    }
}
