using Microsoft.AspNetCore.Mvc;
using MyApi.Enums;
using MyApi.Models;
using System;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository.IRepository _repo;
        public EmployeeController(IRepository.IRepository repository)
        {
            _repo = repository;
        }
        [HttpGet]
        public OkObjectResult Get()
        {
            return Ok(_repo.GetAll());
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest();
            employee.Id = Guid.NewGuid();
            _repo.Create(employee);
            return CreatedAtAction(nameof(GetById), new { Id = employee.Id }, employee);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Employee findEmployee = _repo.Get(id);
            if(findEmployee == null)
            {
                return NotFound();
            }

            return Ok(findEmployee);
        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Employee employeeToUpdate)
        {
            if (!ModelState.IsValid) return BadRequest();

            Employee employee = _repo.Get(id);
            if(employee == null)
            {
                return NotFound();
            }
            employeeToUpdate.Id = employee.Id;

            _repo.Update(employeeToUpdate);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Employee find = _repo.Get(id);
            if(find == null)
            {
                return NotFound(find);
            }
            _repo.Delete(find);
            return base.Content($"The employee with Id = {id} has been deleted successfully!");
        }

        [HttpGet("gender")]
        public IActionResult CountEmployeeByGender(Gender gender)
        {
            return Content($"Total number of [Gender] {gender} employee resource is " + _repo.CountEmployeeByGender(gender: gender));
        }
    }
}
