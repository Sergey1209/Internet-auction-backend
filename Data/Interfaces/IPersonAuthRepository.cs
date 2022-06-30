using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{

    /// <summary>
    /// Provides a data access mechanism for authenticating registered users
    /// </summary>
    public interface IPersonAuthRepository
    {
        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PersonAuth>> GetAllAsync();
        /// <summary>
        /// Returns entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PersonAuth> GetByIdAsync(int personId);
        /// <summary>
        /// Returns entity by login id
        /// </summary>
        /// <param name="id">Login id</param>
        /// <returns></returns>
        Task<PersonAuth> GetByLoginAsync(string login);
        /// <summary>
        /// Adds an entity to the data source
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(PersonAuth entity);
        /// <summary>
        /// Removes an entity from the data source
        /// </summary>
        /// <param name="entity"></param>
        void Delete(PersonAuth entity);
        /// <summary>
        /// Removes an entity by login id from the data source
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteByLoginAsync(string login);
        /// <summary>
        /// Removes an entity by id from the data source
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(int personId);
        /// <summary>
        /// Updates entity in the data source
        /// </summary>
        /// <param name="entity"></param>
        void Update(PersonAuth entity);
    }
}
