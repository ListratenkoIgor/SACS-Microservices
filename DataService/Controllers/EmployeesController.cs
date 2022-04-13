using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Interfaces;
using Interfaces.DTOs;
using DataService.Data;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : MyControllerBase
    {
        public EmployeesController(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        [HttpGet]
        public IEnumerable<Employee> GetEmployees() => _unitOfWork.Employees.GetEmployees();

        [HttpGet("{urlId}")]
        public Employee GetEmployeeByUrlId(string urlId) => _unitOfWork.Employees.GetEmployeeByUrlId(urlId);

        [HttpPost]
        public void Post([FromBody] EmployeeDto value)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var employee = _mapper.Map<Employee>(value);
                _unitOfWork.Employees.Add(employee);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDto value)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var employee = _mapper.Map<Employee>(value);
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
