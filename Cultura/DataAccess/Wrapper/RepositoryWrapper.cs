//using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;



namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Cultura_bdContext _repoContext;
        private IUserRepository _employee;
        public IUserRepository Employee
        {
            get
            {
                if(_employee == null )
                {
                    _employee = new UserRepository(_repoContext);
                }
                return _employee;
            }
        }
       
        public RepositoryWrapper(Cultura_bdContext repoitoryContext)
        {
            _repoContext = repoitoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}


