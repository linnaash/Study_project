using Domain.Interfaces;
//using DataAccess.Models;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Employee>, IUserRepository
    {
        public UserRepository(Cultura_bdContext repositoryContext) 
            : base(repositoryContext) { 

        }

        }

    }

