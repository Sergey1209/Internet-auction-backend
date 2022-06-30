using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWorkAuth
    {
        /// <summary>
        /// Provides a repository of registered user credentials
        /// </summary>
        IPersonAuthRepository PersonAuthRepository { get; }
        /// <summary>
        /// Provides a repository of personal data of registered users
        /// </summary>
        IPersonRepository PersonRepository { get; }
        Task SaveAsync();
    }
}
