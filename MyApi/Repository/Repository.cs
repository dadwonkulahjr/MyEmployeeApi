using MyApi.Enums;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Repository
{
    public class Repository : IRepository.IRepository
    {
        private List<Employee> _list;
        public Repository()
        {
            _list = new()
            {
                new() { Id = Guid.NewGuid(), FirstName = "Mike", LastName = "Simson", Email = "mike@m.com", Gender = Enums.Gender.Male },
                new() { Id = Guid.NewGuid(), FirstName = "Mary", LastName = "Thomas", Email = "mary@m.com", Gender = Enums.Gender.Female },
                new() { Id = Guid.NewGuid(), FirstName = "John", LastName = "Strong", Email = "john@j.com", Gender = Enums.Gender.Male },
                new() { Id = Guid.NewGuid(), FirstName = "Sara", LastName = "Welleh", Email = "s@s.com",
                Gender = Enums.Gender.Female
                }
            };

        }
        public Employee Create(Employee newEmployee)
        {
            _list.Add(newEmployee);
            return newEmployee;
        }
        public Employee Delete(Employee employee)
        {
            var employeeToDelete = _list.FirstOrDefault(e => e.Id == employee.Id);
            if(employeeToDelete != null)
            {
                _list.Remove(employeeToDelete);
                return employeeToDelete;
            }
            return null;
        }
        public Employee Delete(Guid id)
        {
            Employee deleteEmployee = _list.Find(e => e.Id == id);
            if(deleteEmployee != null)
            {
                _list.Remove(deleteEmployee);
                return deleteEmployee;
            }
            return null;
        }
        public Employee Get(Guid id)
        {
            Employee employee = _list.Where(u => u.Id == id).FirstOrDefault();
            return employee;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _list;
        }
        public int CountEmployeeByGender(Gender gender)
        {
            return _list.Count(e => e.Gender == gender);
        }
        public Employee Update(Employee updateExistingEmployee)
        {
            Employee findEmployee = _list.Where(e => e.Id == updateExistingEmployee.Id).FirstOrDefault();
            if(findEmployee != null)
            {
                findEmployee.FirstName = updateExistingEmployee.FirstName;
                findEmployee.LastName = updateExistingEmployee.LastName;
                findEmployee.Gender = updateExistingEmployee.Gender;
                findEmployee.Email = updateExistingEmployee.Email;
                return updateExistingEmployee;
            }

            return null;
        }
    }
}
