using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        public Task<object> LoginAsync(LoginModel login);
        public Task RegistrationAsync(RegistrationModel registration);
        public Task DeleteAsync(string login);
        public Task UpdateAsyc(PersonAuthModel model);
    }
}
