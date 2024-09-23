﻿using Domain.Models;

namespace Domain.Interfaces
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
