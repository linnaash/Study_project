using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper=repositoryWrapper;
        }
        public Task<List<Employee>> GetAll()
        {
            return _repositoryWrapper.Employee.FindAll().ToListAsync();
        }
        public Task<Employee> GetById(int id)
        {
            var user = _repositoryWrapper.Employee.FindByCondition(x => x.EmployeeId == id).First();
            return Task.FromResult(user);
        }
        public  Task Create(Employee model) 
        {
            _repositoryWrapper.Employee.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Employee model) 
        {
          _repositoryWrapper.Employee.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id) 
        {
            var user = _repositoryWrapper.Employee.FindByCondition(x => x.EmployeeId==id).First();
            _repositoryWrapper.Employee.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

    }
}
