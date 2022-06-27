using Data.Entities;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        Task<int> GetIdByNameAsync(string name);
    }
}
