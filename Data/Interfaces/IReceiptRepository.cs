using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        public Task<IEnumerable<Receipt>> GetAllWithDetailsAsync();
        public Task<Receipt> GetByIdWithDetailsAsync(int id);
    }
}
