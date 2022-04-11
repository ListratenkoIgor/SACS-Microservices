using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Interfaces;
using DataService.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public EmployeesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Employee> GetEmployees() => _unitOfWork.Employees.GetEmployees();

        [HttpGet("{urlId}")]
        public Employee GetEmployeeByUrlId(string urlId) => _unitOfWork.Employees.GetEmployeeByUrlId(urlId);

        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.Employees.Add(employee);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.Employees.Update(employee);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var employee = _unitOfWork.Employees.FindAsync(id);
                employee.Wait();
                _unitOfWork.Employees.Remove(employee.Result);
                _unitOfWork.SaveAsync().Wait();
            }
        }
    }
}
