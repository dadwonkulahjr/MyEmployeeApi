using MyApi.Enums;
using MyApi.Models;
using System;
using System.Collections.Generic;

namespace MyApi.IRepository
{
    public interface IRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(Guid id);
        Employee Create(Employee newEmployee);
        Employee Update(Employee updateExistingEmployee);
        int CountEmployeeByGender(Gender gender);
        Employee Delete(Employee employee);
        Employee Delete(Guid id);
    }
}
