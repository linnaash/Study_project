using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}


