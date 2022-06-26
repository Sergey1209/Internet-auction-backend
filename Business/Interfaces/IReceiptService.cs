using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IReceiptService
    {
        public Task<IEnumerable<ReceiptModel>> GetAllAsync();
        public Task<ReceiptModel> GetByIdAsync(int modelId);
        public Task AddAsync(ReceiptModel model);
    }
}
