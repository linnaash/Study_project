using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);

        Task Create(Employee model);
        Task Update(Employee model);
        Task Delete(int id);
    }
}
