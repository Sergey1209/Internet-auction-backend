using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersonAuthRepository
    {
        Task<IEnumerable<PersonAuth>> GetAllAsync();
        Task<PersonAuth> GetByIdAsync(int personId);
        Task<PersonAuth> GetByLoginAsync(string login);
        Task AddAsync(PersonAuth entity);
        void Delete(PersonAuth entity);
        Task DeleteByLoginAsync(string login);
        Task DeleteByIdAsync(int personId);
        void Update(PersonAuth entity);
    }
}
