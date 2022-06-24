using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        Task<int> GetIdByNameAsync(string name);
    }
}
