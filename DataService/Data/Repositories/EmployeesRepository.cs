using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Interfaces.Models;

namespace DataService.Data.Repositories
{
    public class EmployeesRepository: RepositoryBase<Employee>
    {
        public EmployeesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }

        public Employee GetEmployeeByUrlId(string urlId)
        {
            var query =
               from employee in ApplicationDbContext.Employees
               where employee.UrlId == urlId
               select employee;
            return query.FirstOrDefault();
        }

        internal IEnumerable<Employee> GetEmployees()
        {
            var query =
               from employee in ApplicationDbContext.Employees
               select employee;
            return query;
        }
    }
}