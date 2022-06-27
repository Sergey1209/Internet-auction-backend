using Data.Data;
using Data.Interfaces;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWorkAuth : IUnitOfWorkAuth
    {
        private readonly AuthDbContext _dbContext;
        IPersonAuthRepository _personAuthRepository;
        IPersonRepository _personRepository;

        public UnitOfWorkAuth(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPersonAuthRepository PersonAuthRepository
        {
            get
            {
                if (_personAuthRepository == null)
                    _personAuthRepository = new PersonAuthRepository(_dbContext);

                return _personAuthRepository;
            }

        }

        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new PersonRepository(_dbContext);

                return _personRepository;
            }

        }


        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
