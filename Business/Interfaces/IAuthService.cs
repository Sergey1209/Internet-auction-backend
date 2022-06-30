using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Provides tools for handling user authentication controller data.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// User authentication
        /// </summary>
        /// <param name="login">User authentication data</param>
        /// <returns></returns>
        public Task<object> LoginAsync(LoginModel login);
        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="registration">User registration data</param>
        /// <returns></returns>
        public Task RegistrationAsync(RegistrationModel registration);
        /// <summary>
        /// Removes user
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns></returns>
        public Task DeleteAsync(string email);
        /// <summary>
        /// Updates personal data and user authentication data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateAsyc(PersonModel model);
    }
}
