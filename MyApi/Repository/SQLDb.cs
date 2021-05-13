using MyApi.DataAccess;
using MyApi.Enums;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Repository
{
    public class SQLDb : IRepository.IRepository
    {
        protected internal AppDbContext _dbContext;
        public SQLDb()
        {

        }
        public SQLDb(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public int CountEmployeeByGender(Gender gender)
        {
            return _dbContext.Employee.Where(e => e.Gender == gender).Count();
        }

        public Employee Create(Employee newEmployee)
        {
            var result = _dbContext.Employee.AddAsync(newEmployee).GetAwaiter().GetResult();
            _dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            return result.Entity;
        }

        public Employee Delete(Employee employee)
        {
            var result = _dbContext.Employee.FindAsync(employee.Id).GetAwaiter().GetResult();
            if (result != null)
            {
                //Emploee has been found!
                //Process the data...
                _dbContext.Remove(result);
                _dbContext.SaveChangesAsync().GetAwaiter().GetResult();
                return result;
            }
            return null;
        }

        public Employee Delete(Guid id)
        {
            var result = _dbContext.Employee.FindAsync(id).GetAwaiter().GetResult();
            if (result != null)
            {
                //Emploee has been found!
                //Process the data...
                _dbContext.Remove(result);
                _dbContext.SaveChangesAsync().GetAwaiter().GetResult();
                return result;
            }
            return null;
        }

        public Employee Get(Guid id)
        {
            return _dbContext.Employee.FindAsync(id).GetAwaiter().GetResult();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employee;
        }

        public Employee Update(Employee updateExistingEmployee)
        {
            var result = _dbContext.Employee.FindAsync(updateExistingEmployee.Id).GetAwaiter().GetResult();
            if(result != null)
            {
                result.FirstName = updateExistingEmployee.FirstName;
                result.LastName = updateExistingEmployee.LastName;
                result.Email = updateExistingEmployee.Email;
                result.Gender = updateExistingEmployee.Gender;
                _dbContext.SaveChangesAsync().GetAwaiter().GetResult();
                return result;

            }

            return null;
        }
    }
}
