using Data.Entities;

namespace Data.Interfaces
{
    /// <summary>
    /// Provides a mechanism for accessing the personal data of registered users
    /// </summary>
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
