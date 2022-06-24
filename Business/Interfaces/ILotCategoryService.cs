using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILotCategoryService : ICrud<LotCategoryModel>
    {
        public Task AddAsync(string name, int? fileId);
        public Task UpdateAsyc(InputLotCategoryModel model);
        public Task<int> GetFileId(int lotCategoryId);
    }
}
