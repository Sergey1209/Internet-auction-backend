using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWorkAuth
    {
        IPersonAuthRepository PersonAuthRepository { get; }
        IPersonRepository PersonRepository { get; }
        Task SaveAsync();
    }
}
