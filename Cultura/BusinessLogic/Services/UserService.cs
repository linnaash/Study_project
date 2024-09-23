using Domain.Models;
using Domain.Interfaces;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _repositoryWrapper.Employee.FindAll();
        }

        public async Task<Employee> GetById(int id)
        {
            var user = await _repositoryWrapper.Employee
                .FindByCondition(x => x.EmployeeId == id);
            return user.FirstOrDefault();
        }

        public async Task Create(Employee model)
        {
            await _repositoryWrapper.Employee.Create(model);
            await _repositoryWrapper.Save(); 
        }

        public async Task Update(Employee model)
        {
            _repositoryWrapper.Employee.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Employee
                .FindByCondition(x => x.EmployeeId == id);

            var employeeToDelete = user.FirstOrDefault();
            if (employeeToDelete != null)
            {
                _repositoryWrapper.Employee.Delete(employeeToDelete);
                await _repositoryWrapper.Save();
            }
        }
    }
}
