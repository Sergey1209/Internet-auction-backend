using Data.Entities;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        /// <summary>
        /// Returns id entity by the entity name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> GetIdByNameAsync(string name);
    }
}
